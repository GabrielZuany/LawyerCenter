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
    [Route("api/v1/lawyer")]
    public class LawyerController : ControllerBase
    {
        private readonly ILawyerRepository _lawyerRepository;
        private readonly ILawyerCategoryRepository _lawyerCategoryRepository;
        private readonly ILogger<LawyerController> _logger;
        private readonly DataEncryptionSevice _dataEncryptionSevice = new();

        public LawyerController(ILawyerRepository lawyerRepository, ILawyerCategoryRepository lawyerCategoryRepository, ILogger<LawyerController> logger)
        {
            _lawyerCategoryRepository = lawyerCategoryRepository ?? throw new ArgumentNullException(nameof(lawyerCategoryRepository));
            _lawyerRepository = lawyerRepository ?? throw new ArgumentNullException(nameof(lawyerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]LawyerViewModel lawyerViewModel)
        {
            try
            {
                LawyerCategory? lc =  await _lawyerCategoryRepository.Get(lawyerViewModel.CategoryAlias);  
                if(lc == null)
                {
                    _logger.LogError("Lawyer category not found!");
                    return StatusCode(500);
                }
                Guid categoryId = lc.Id;  
                byte[] encryptedPassword = await _dataEncryptionSevice.EncryptAsync(lawyerViewModel.Password);
                byte[] encryptedCpf = await _dataEncryptionSevice.EncryptAsync(lawyerViewModel.Cpf);
                byte[] encryptedProfessionalId = await _dataEncryptionSevice.EncryptAsync(lawyerViewModel.ProfessionalId);
                byte[] encryptedPostalcode = await _dataEncryptionSevice.EncryptAsync(lawyerViewModel.Postalcode);
                string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);
                string encryptedCpfString = Convert.ToBase64String(encryptedCpf);
                string encryptedProfessionalIdString = Convert.ToBase64String(encryptedProfessionalId);
                string encryptedPostalcodeString = Convert.ToBase64String(encryptedPostalcode);

                var lawyer = new Lawyer(
                    Guid.NewGuid(), 
                    lawyerViewModel.Name, 
                    encryptedCpfString, 
                    encryptedProfessionalIdString, 
                    categoryId, 
                    encryptedPostalcodeString,
                    lawyerViewModel.State, 
                    lawyerViewModel.City, 
                    DateTime.Now.ToUniversalTime(), 
                    null, 
                    lawyerViewModel.Photo,
                    lawyerViewModel.Email,
                    encryptedPasswordString,
                    lawyerViewModel.Description,
                    lawyerViewModel.Age
                    );
                await _lawyerRepository.Create(lawyer);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error adding lawyer");
                return StatusCode(500);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]LawyerViewModel lawyerViewModel)
        {
            try
            {
                LawyerCategory? lc =  await _lawyerCategoryRepository.Get(lawyerViewModel.CategoryAlias);
                byte[] encryptedPassword = await _dataEncryptionSevice.EncryptAsync(lawyerViewModel.Password);
                byte[] encryptedCpf = await _dataEncryptionSevice.EncryptAsync(lawyerViewModel.Cpf);
                byte[] encryptedProfessionalId = await _dataEncryptionSevice.EncryptAsync(lawyerViewModel.ProfessionalId);
                byte[] encryptedPostalcode = await _dataEncryptionSevice.EncryptAsync(lawyerViewModel.Postalcode);
                string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);
                string encryptedCpfString = Convert.ToBase64String(encryptedCpf);
                string encryptedProfessionalIdString = Convert.ToBase64String(encryptedProfessionalId);
                string encryptedPostalcodeString = Convert.ToBase64String(encryptedPostalcode);

                var old = await _lawyerRepository.Login(lawyerViewModel.Email, encryptedCpfString, encryptedPasswordString);

                var lawyer = new Lawyer(
                    old!.Id, 
                    lawyerViewModel.Name, 
                    encryptedCpfString, 
                    encryptedProfessionalIdString, 
                    lc?.Id ?? old!.LawyerCategoryId, 
                    encryptedPostalcodeString, 
                    lawyerViewModel.State, 
                    lawyerViewModel.City, 
                    old!.RegistrationDate.ToUniversalTime(), 
                    DateTime.Now.ToUniversalTime(), 
                    lawyerViewModel.Photo,
                    lawyerViewModel.Email,
                    encryptedPasswordString,
                    lawyerViewModel.Description,
                    lawyerViewModel.Age
                    );

                await _lawyerRepository.Update(lawyer);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error updating lawyer");
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

                var old = await _lawyerRepository.Login(email, encryptedCpfString, encryptedPasswordString);
                if (old == null) {
                    _logger.LogError("Lawyer not found!");
                    return StatusCode(500);
                }
                await _lawyerRepository.Delete(old!);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error deleting lawyer");
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string email, string cpf, string password)
        {
            byte[] encryptedPassword = await _dataEncryptionSevice.EncryptAsync(password);
            byte[] encryptedCpf = await _dataEncryptionSevice.EncryptAsync(cpf);
            string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);
            string encryptedCpfString = Convert.ToBase64String(encryptedCpf);
            var lawyer = await _lawyerRepository.Login(email, encryptedCpfString, encryptedPasswordString);
            if(lawyer == null)
            {
                _logger.LogError("Lawyer not found!");
                return StatusCode(500);
            }
            return Ok(lawyer);
        }

        [HttpGet("getpage")]
        public async Task<IActionResult> GetPage(int skip, int take)
        {
            var lawyers = await _lawyerRepository.GetPage(skip, take);
            return Ok(lawyers);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var lawyer = await _lawyerRepository.GetById(id);
            if(lawyer == null)
            {
                _logger.LogError("Lawyer not found!");
                return StatusCode(500);
            }
            return Ok(lawyer);
        }

        [HttpGet("getfiltered")]
        public async Task<IActionResult> GetFiltered(int skip, int take, string? category, string? state)
        {
            var lawyers = await _lawyerRepository.GetFiltered(skip, take, category, state);
            if (lawyers == null)
            {
                _logger.LogError("Lawyers not found!");
                return StatusCode(500);
            }            
            return Ok(lawyers);
        }
    }
}