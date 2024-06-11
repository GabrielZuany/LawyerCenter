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
                var lawyer = new Lawyer(lawyerViewModel.Name, lawyerViewModel.Cpf, lawyerViewModel.ProfessionalId, lawyerViewModel.LawyerCategoryId, lawyerViewModel.Postalcode, lawyerViewModel.Country, lawyerViewModel.State, lawyerViewModel.City, DateTime.Now, null, lawyerViewModel.Photo);
                _lawyerRepository.Create(lawyer);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error adding lawyer");
                return StatusCode(500);
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody]LawyerViewModel lawyerViewModel)
        {
            try
            {
                var lawyer = new Lawyer(lawyerViewModel.Name, lawyerViewModel.Cpf, lawyerViewModel.ProfessionalId, lawyerViewModel.LawyerCategoryId, lawyerViewModel.Postalcode, lawyerViewModel.Country, lawyerViewModel.State, lawyerViewModel.City, DateTime.Now, DateTime.Now, lawyerViewModel.Photo);
                _lawyerRepository.Update(lawyer);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error updating lawyer");
                return StatusCode(500);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody]LawyerViewModel lawyerViewModel)
        {
            try
            {
                var lawyer = new Lawyer(lawyerViewModel.Name, lawyerViewModel.Cpf, lawyerViewModel.ProfessionalId, lawyerViewModel.LawyerCategoryId, lawyerViewModel.Postalcode, lawyerViewModel.Country, lawyerViewModel.State, lawyerViewModel.City, DateTime.Now, null, lawyerViewModel.Photo);
                _lawyerRepository.Delete(lawyer);
                return Ok();
            }catch(Exception e)
            {
                _logger.LogError(e, "Error deleting lawyer");
                return StatusCode(500);
            }
        }

        [HttpPut("get")]
        public IActionResult Get(string email, string cpf, string password)
        {
            var lawyer = _lawyerRepository.Get(email, cpf, password);
            if(lawyer == null)
            {
                _logger.LogError("Lawyer not found!");
                return StatusCode(500);
            }
            return Ok(lawyer);
        }
    }
}