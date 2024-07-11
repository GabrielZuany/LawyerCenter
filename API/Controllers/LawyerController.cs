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

        private static bool ValidCPF(string cpf)
        {
            if (cpf.Any(c => !char.IsDigit(c))) { return false; }
            return true;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]LawyerViewModel lawyerViewModel)
        {
            if (!ValidCPF(lawyerViewModel.Cpf)) return BadRequest("CPF label must contain only numeric values.");
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
            if (!ValidCPF(lawyerViewModel.Cpf)) return BadRequest("CPF label must contain only numeric values.");
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
            if (!ValidCPF(cpf)) return BadRequest("CPF label must contain only numeric values.");
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
            if (!ValidCPF(cpf)) return BadRequest("CPF label must contain only numeric values.");

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
            if (skip < 0 || take < 0) 
            { 
                _logger.LogError($"Skip and Take must be positive values.");
                return BadRequest();
            }
            try
            {
                var lawyers = await _lawyerRepository.GetPage(skip, take);
                return Ok(lawyers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
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
            string decryptedCpf = await _dataEncryptionSevice.DecryptAsync(Convert.FromBase64String(lawyer.Cpf));
            var newLawyer = new Lawyer(
                lawyer.Id,
                lawyer.Name,
                decryptedCpf,
                lawyer.ProfessionalId,
                lawyer.LawyerCategoryId,
                lawyer.Postalcode,
                lawyer.State,
                lawyer.City,
                lawyer.RegistrationDate,
                lawyer.LastUpdate,
                lawyer.Photo,
                lawyer.Email,
                "",
                lawyer.Description,
                lawyer.Age
            );
            return Ok(newLawyer);
        }

        [HttpGet("get-filtered")]    
        public async Task<IActionResult> GetPageFiltered(int skip, int take, string? category, string? state)
        {
            if (skip < 0 || take < 0)
            {
                _logger.LogError($"Skip and Take must be positive values.");
                return BadRequest();
            }

            var lawyers = await _lawyerRepository.GetPageFiltered(skip, take, category, state);
            if (lawyers == null)
            {
                _logger.LogError("Lawyers not found!");
                return StatusCode(500);
            }            
            return Ok(lawyers);
        }

        [HttpGet("get-all-filtered")]
        public async Task<IActionResult> GetFiltered(string? category, string? state)
        {
            var lawyers = await _lawyerRepository.GetAllFiltered(category, state);
            if (lawyers == null)
            {
                _logger.LogError("Lawyers not found!");
                return StatusCode(500);
            }
            return Ok(lawyers);
        }

        [HttpGet("get-all-filtered-count")]
        public async Task<IActionResult> GetAllFilteredCount(string? category, string? state)
        {
            return Ok(await _lawyerRepository.CountAllFiltered(category, state));
        }

        [HttpGet("get-category")]
        public async Task<IActionResult> GetCategory(Guid lawyerId)
        {
            Lawyer? lawyer = await _lawyerRepository.GetById(lawyerId);
            if (lawyer == null)
            {
                _logger.LogError("Lawyer not found!");
                return StatusCode(500);
            }
            LawyerCategory? category = await _lawyerCategoryRepository.Get(lawyer.LawyerCategoryId);
            if (category == null)
            {
                _logger.LogError("Category not found!");
                return StatusCode(500);
            }
            return Ok(category);
        }
    }
}