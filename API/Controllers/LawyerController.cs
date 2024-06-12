using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.Repository.Interfaces;
using Microsoft.OpenApi.Validations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/lawyer")]
    public class LawyerController : ControllerBase
    {
        private readonly ILawyerRepository _lawyerRepository;
        private readonly ILogger<LawyerController> _logger;

        public LawyerController(ILawyerRepository lawyerRepository, ILogger<LawyerController> logger)
        {
            _lawyerRepository = lawyerRepository ?? throw new ArgumentNullException(nameof(lawyerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]LawyerViewModel lawyerViewModel)
        {
            try
            {
                var lawyer = new Lawyer(Guid.NewGuid(), lawyerViewModel.Name, lawyerViewModel.Cpf, lawyerViewModel.ProfessionalId, lawyerViewModel.LawyerCategoryId, lawyerViewModel.Postalcode, lawyerViewModel.Country, lawyerViewModel.State, lawyerViewModel.City, DateTime.Now.ToUniversalTime(), null, lawyerViewModel.Photo);
                _lawyerRepository.Create(lawyer);
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
                var old = await _lawyerRepository.Get(lawyerViewModel.Email, lawyerViewModel.Cpf, lawyerViewModel.Password);
                var lawyer = new Lawyer(old!.Id, lawyerViewModel.Name, lawyerViewModel.Cpf, lawyerViewModel.ProfessionalId, lawyerViewModel.LawyerCategoryId, lawyerViewModel.Postalcode, lawyerViewModel.Country, lawyerViewModel.State, lawyerViewModel.City, old!.RegistrationDate.ToUniversalTime(), DateTime.Now.ToUniversalTime(), lawyerViewModel.Photo);
                await _lawyerRepository.Update(lawyer);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error updating lawyer");
                return StatusCode(500);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody]LawyerViewModel lawyerViewModel)
        {
            try
            {
                var old = await _lawyerRepository.Get(lawyerViewModel.Email, lawyerViewModel.Cpf, lawyerViewModel.Password);
                await _lawyerRepository.Delete(old!);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error deleting lawyer");
                return StatusCode(500);
            }
        }

        [HttpPut("get")]
        public async Task<IActionResult> Get(string email, string cpf, string password)
        {
            var lawyer = await _lawyerRepository.Get(email, cpf, password);
            if(lawyer == null)
            {
                _logger.LogError("Lawyer not found!");
                return StatusCode(500);
            }
            return Ok(lawyer);
        }
    }
}