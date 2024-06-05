using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.Repository.Interfaces;
using API.ViewModel;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/system-user")]
    public class SystemUserController : ControllerBase
    {
        private readonly ISystemUserRepository _systemUserRepository;
        private readonly ILogger<SystemUserController> _logger;

        public SystemUserController(ISystemUserRepository systemUserRepository, ILogger<SystemUserController> logger)
        {
            _systemUserRepository = systemUserRepository ?? throw new ArgumentNullException(nameof(systemUserRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm]SystemUserViewModel systemUserView)
        {
            try
            {
                var systemUser = new SystemUser(systemUserView.Email, systemUserView.Password, systemUserView.Role, DateTime.Now, null);
                _systemUserRepository.Create(systemUser);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error adding system user");
                return StatusCode(500);
            }
        }

        [HttpPost("verify")]
        public IActionResult Login([FromBody]SystemUserViewModel systemUserView)
        {
            var systemUser = _systemUserRepository.Get(systemUserView.Email);
            if(systemUser == null)
            {
                _logger.LogError("User not found!");
                return StatusCode(500);
            }
            if(systemUser.Password != systemUserView.Password)
            {
                _logger.LogError("Invalid password!");
                return StatusCode(500);
            }
            _logger.LogInformation("Logged in!");
            return Ok(systemUser);
        }

    }
}