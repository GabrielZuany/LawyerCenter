using API.Controllers;
using API.Infra;
using API.Model;
using API.Repository;
using API.Repository.Interfaces;
using API.Services;
using API.ViewModel;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Tests.RoutesTests
{
    public class ClientControllerTests
    {
        private readonly ClientController _controller;
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<ClientController> _logger;
        private readonly DataEncryptionSevice _dataEncryptionSevice = new();
        private readonly ConnectionContext _context = new ConnectionContext();

        public ClientControllerTests()
        {
            // SUT - System Under Test
            _clientRepository = new ClientRepository();
            _logger = A.Fake<ILogger<ClientController>>();
            _controller = new ClientController(_clientRepository, _logger);
        }

        [Fact]
        public async Task CreateTest()
        {
            var vm = new ClientViewModel()
            {
                Name = "Xunit",
                Cpf = "987654321XX",
                Email = "xunit@mail.com",
                Password = "password",
                Postalcode = "29060701",
                State = "XU",
                City = "xunit",
                Photo = "null"
            };

            // invalid
            var result = await _controller.Create(vm);
            Assert.IsType<BadRequestObjectResult>(result);

            // valid
            vm.Cpf = "98765478998";
            result = await _controller.Create(vm);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateTest()
        {
            string email = "xunit@mail.com";
            string password = "password";
            var vm = new ClientViewModel()
            {
                Name = "Xunit",
                Cpf = "987654321XX",
                Email = "xunit_new@mail.com",
                Password = "password_new",
                Postalcode = "29060701",
                State = "XU",
                City = "xunit",
                Photo = "null"
            };

            // invalid cpf => bad request
            var result = await _controller.Update(email, password, vm);
            Assert.IsType<BadRequestObjectResult>(result);

            // invalid pwd => login error
            vm.Cpf = "98765478998";
            result = await _controller.Update("email", password, vm);
            var status = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(status.StatusCode, new StatusCodeResult(404).StatusCode);

            // valid
            result = await _controller.Update(email, password, vm);
            Assert.IsType<OkResult>(result);
        }


        [Theory]
        [InlineData("xunit@mail.com", "987654321XX", "password")] // invalid cpf
        [InlineData("xunit@mail.com", "98765478998", "passwordddd")] // invalid credentials
        [InlineData("xunit_new@mail.com", "98765478998", "password_new")] // valid credentials
        public async Task GetTest(string? email, string? cpf, string password)
        {
            var result = await _controller.Get(email, cpf, password);
            if (result is OkObjectResult okResult)
            {
                Assert.NotNull(okResult);
                Assert.IsType<Client>(okResult.Value);
                return;
            }
            if (result is StatusCodeResult statusResult)
            {
                Assert.Equal(500, statusResult.StatusCode);
                return;
            }
            if (result is NotFoundObjectResult notFound)
            {
                Assert.Equal(404, notFound.StatusCode);
                return;
            }
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteTest()
        {
            string email = "xunit_new@mail.com";
            string password = "password_new";
            string cpf = "98765478998";

            // invalid cpf => bad request
            var result = await _controller.Delete(email, "987654789XX", password);
            Assert.IsType<BadRequestObjectResult>(result);

            // invalid cpf => login error
            result = await _controller.Delete(email, "98765478999", password);
            var status = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(status.StatusCode, new StatusCodeResult(404).StatusCode);

            // valid
            result = await _controller.Delete(email, cpf, password);
            Assert.IsType<OkResult>(result);
        }
    }
}
