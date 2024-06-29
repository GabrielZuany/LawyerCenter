using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.Repository.Interfaces;
using Microsoft.OpenApi.Validations;
using API.Services;
using API.Infra.Repository;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/client-lawyer")]
    public class ClientLawyerController : ControllerBase
    {
        private readonly ILawyerRepository _lawyerRepository;
        private readonly IClientLawyerRepository _clientLawyerRepository;
        private readonly ILogger<LawyerController> _logger;

        public ClientLawyerController(ILawyerRepository lawyerRepository, IClientLawyerRepository clientLawyerRepository, ILogger<LawyerController> logger)
        {
            _clientLawyerRepository = clientLawyerRepository ?? throw new ArgumentNullException(nameof(clientLawyerRepository));
            _lawyerRepository = lawyerRepository ?? throw new ArgumentNullException(nameof(lawyerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("/get-relations")]
        public async Task<IActionResult> Get(Guid? lawyerId, Guid? clientId)
        {
            if (lawyerId == null && clientId == null)
            {
                _logger.LogError($"No relations found between {lawyerId} and {clientId}.");
                return BadRequest();
            }
            IEnumerable<ClientLawyer> relation;
            if (clientId == null)
            {
                relation = await _clientLawyerRepository.GetByLawyerId((Guid)lawyerId);
                if (relation == null)
                {
                    _logger.LogError($"No relations found between {lawyerId} and {clientId}.");
                    return BadRequest();
                }
                return Ok(relation);
            }
            if (lawyerId == null)
            {
                relation = await _clientLawyerRepository.GetByClientId((Guid)clientId);
                if (relation == null)
                {
                    _logger.LogError($"No relations found between {lawyerId} and {clientId}.");
                    return BadRequest();
                }
                return Ok(relation);
            }
            relation = await _clientLawyerRepository.GetRelationBetween(lawyerId, clientId); if (relation == null)
            {
                _logger.LogError($"No relations found between {lawyerId} and {clientId}.");
                return BadRequest();
            }
            return Ok(relation);
        }

        [HttpPost("/create-relation")]
        public async Task<IActionResult> Create(Guid lawyerId, Guid clientId)
        {
            try
            {
                ClientLawyer clientLawyer = new ClientLawyer
                {
                    Id = new Guid(),
                    ClientId = clientId,
                    LawyerId = lawyerId,
                    RelationCreatedIn = DateTime.Now.ToUniversalTime()
                };
                return Ok(await _clientLawyerRepository.Create(clientLawyer));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create relation falied!\n{ex.ToString()}");
            }
            return BadRequest();
        }
    }
}
