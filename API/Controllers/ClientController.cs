using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.Repository.Interfaces;
using Microsoft.OpenApi.Validations;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<ClientController> _logger;
        private readonly DataEncryptionSevice _dataEncryptionSevice = new();

        public ClientController(IClientRepository clientRepository, ILogger<ClientController> logger)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]ClientViewModel clientViewModel)
        {
            try
            {
                byte[] encryptedPassword = await _dataEncryptionSevice.EncryptAsync(clientViewModel.Password);
                byte[] encryptedCpf = await _dataEncryptionSevice.EncryptAsync(clientViewModel.Cpf);
                byte[] encryptedPostalcode = await _dataEncryptionSevice.EncryptAsync(clientViewModel.Postalcode);
                string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);
                string encryptedCpfString = Convert.ToBase64String(encryptedCpf);
                string encryptedPostalcodeString = Convert.ToBase64String(encryptedPostalcode);

                var client = new Client(
                    Guid.NewGuid(), 
                    clientViewModel.Name, 
                    encryptedCpfString, 
                    clientViewModel.Email, 
                    encryptedPasswordString, 
                    encryptedPostalcodeString, 
                    clientViewModel.Country, 
                    clientViewModel.State, 
                    clientViewModel.City, 
                    DateTime.Now.ToUniversalTime(), 
                    null, 
                    clientViewModel.Photo);
                await _clientRepository.Create(client);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error adding client");
                return StatusCode(500);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(string email, string password, [FromBody]ClientViewModel newClientViewModel)
        {
            try
            {
                byte[] encryptedPassword = await _dataEncryptionSevice.EncryptAsync(password);
                string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);
                var old = await _clientRepository.Get(email, null, encryptedPasswordString);
                if(old == null){ return NotFound(); }

                byte[] newEncryptedCpf = await _dataEncryptionSevice.EncryptAsync(newClientViewModel.Cpf);
                byte[] newEncryptedPostalcode = await _dataEncryptionSevice.EncryptAsync(newClientViewModel.Postalcode);
                byte[] newEncryptedPassword = await _dataEncryptionSevice.EncryptAsync(newClientViewModel.Password);
                string newEncryptedCpfString = Convert.ToBase64String(newEncryptedCpf);
                string newEncryptedPostalcodeString = Convert.ToBase64String(newEncryptedPostalcode);
                string newEncryptedPasswordString = Convert.ToBase64String(newEncryptedPassword);

                old.Name = newClientViewModel.Name;
                old.Email = newClientViewModel.Email;
                old.Cpf = newEncryptedCpfString;
                old.Password = newEncryptedPasswordString;
                old.Photo = newClientViewModel.Photo;
                old.Postalcode = newEncryptedPostalcodeString;
                old.Country = newClientViewModel.Country;
                old.State = newClientViewModel.State;
                old.City = newClientViewModel.City;
                old.RegistrationDate = old.RegistrationDate.ToUniversalTime();
                old.LastUpdate = DateTime.Now.ToUniversalTime();

                await _clientRepository.Update(old);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error updating client");
                return StatusCode(500);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string email, string cpf, string password)
        {
            try
            {
                byte[] encryptedPassword = await _dataEncryptionSevice.EncryptAsync(password);
                byte[] encryptedCpf = await _dataEncryptionSevice.EncryptAsync(cpf);
                string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);
                string encryptedCpfString = Convert.ToBase64String(encryptedCpf);
                var old = await _clientRepository.Get(email, encryptedCpfString, encryptedPasswordString);
                await _clientRepository.Delete(old!);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error deleting client");
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string? email, string? cpf, string password)
        {
            try
            {
                byte[] encryptedPassword = await _dataEncryptionSevice.EncryptAsync(password);
                byte[] encryptedCpf = await _dataEncryptionSevice.EncryptAsync(cpf ?? "");
                string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);
                string encryptedCpfString = Convert.ToBase64String(encryptedCpf);
                var client = await _clientRepository.Get(email, encryptedCpfString, encryptedPasswordString);
                return Ok(client);
            }catch(Exception e)
            {
                _logger.LogError(e, "Error getting client");
                return StatusCode(500);
            }
        }
    }
}