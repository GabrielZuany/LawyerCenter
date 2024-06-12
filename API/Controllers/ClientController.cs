using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.Repository.Interfaces;
using Microsoft.OpenApi.Validations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientRepository clientRepository, ILogger<ClientController> logger)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]ClientViewModel clientViewModel)
        {
            try
            {
                var client = new Client(Guid.NewGuid(), clientViewModel.Name, clientViewModel.Cpf, clientViewModel.Email, clientViewModel.Password, clientViewModel.Postalcode, clientViewModel.Country, clientViewModel.State, clientViewModel.City, DateTime.Now.ToUniversalTime(), null, clientViewModel.Photo);
                _clientRepository.Create(client);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error adding client");
                return StatusCode(500);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]ClientViewModel clientViewModel)
        {
            try
            {
                var old = await _clientRepository.Get(clientViewModel.Email, clientViewModel.Cpf, clientViewModel.Password);
                var client = new Client(old!.Id, clientViewModel.Name, clientViewModel.Cpf, clientViewModel.Email, clientViewModel.Password, clientViewModel.Postalcode, clientViewModel.Country, clientViewModel.State, clientViewModel.City, old!.RegistrationDate.ToUniversalTime(), DateTime.Now.ToUniversalTime(), clientViewModel.Photo);
                await _clientRepository.Update(client);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error updating client");
                return StatusCode(500);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody]ClientViewModel clientViewModel)
        {
            try
            {
                var old = await _clientRepository.Get(clientViewModel.Email, clientViewModel.Cpf, clientViewModel.Password);
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
                var client = await _clientRepository.Get(email, cpf, password);
                return Ok(client);
            }catch(Exception e)
            {
                _logger.LogError(e, "Error getting client");
                return StatusCode(500);
            }
        }
    }
}