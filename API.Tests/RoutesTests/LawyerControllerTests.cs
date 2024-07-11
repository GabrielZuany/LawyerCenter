using API.Controllers;
using API.Repository.Interfaces;
using API.Services;
using API.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FakeItEasy;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using API.Infra.Repository;
using API.Repository;
using API.Infra;
using Microsoft.IdentityModel.Tokens;

namespace API.Tests.RoutesTests
{
    public class LawyerControllerTests
    {
        private readonly LawyerController _controller;
        private readonly ILawyerRepository _lawyerRepository;
        private readonly ILawyerCategoryRepository _lawyerCategoryRepository;
        private readonly ILogger<LawyerController> _logger;
        private readonly DataEncryptionSevice _dataEncryptionSevice = new();
        private readonly ConnectionContext _context = new ConnectionContext();
        public LawyerControllerTests() 
        {
            // SUT - System Under Test
            _lawyerRepository = new LawyerRepository();
            _lawyerCategoryRepository = new LawyerCategoryRepository();
            _logger = A.Fake<ILogger<LawyerController>>();
            _controller = new LawyerController(_lawyerRepository, _lawyerCategoryRepository, _logger);
        }

        [Fact]
        public async Task CreateTest()
        {
            var vm = new LawyerViewModel()
            {
                Name = "XUnit",
                Cpf = "987654321AA",
                Email = "xunit@gmail.com",
                Password = "password",
                ProfessionalId = "AL123987",
                Postalcode = "29060701",
                State = "AL",
                City = "SomeCity",
                Photo = "null",
                CategoryAlias = "Tributário",
                Description = "xunit test description",
                Age = 999
            };

            // invalid
            var result = await _controller.Create(vm);
            Assert.IsType<BadRequestObjectResult>(result);

            // invalid
            vm.CategoryAlias = "invalid";
            vm.Cpf = "98765432155";
            result = await _controller.Create(vm);
            var status = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(status.StatusCode, new StatusCodeResult(500).StatusCode);

            // valid
            vm.CategoryAlias = "Tributário";
            result = await _controller.Create(vm);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var vm = new LawyerViewModel()
            {
                Name = "XUnit",
                Cpf = "987654321AA",
                Email = "xunit@gmail.com",
                Password = "password",
                ProfessionalId = "AL123987",
                Postalcode = "29060701",
                State = "AL",
                City = "SomeCity",
                Photo = "null",
                CategoryAlias = "Tributário",
                Description = "xunit test description",
                Age = 999
            };

            // invalid cpf => bad request
            var result = await _controller.Update(vm);
            Assert.IsType<BadRequestObjectResult>(result);

            // invalid cpf => login error
            vm.Cpf = "98765432154";
            result = await _controller.Update(vm);
            var status = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(status.StatusCode, new StatusCodeResult(500).StatusCode);

            // valid
            vm.Cpf = "98765432155";
            result = await _controller.Update(vm);
            //Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var vm = new LawyerViewModel()
            {
                Name = "XUnit",
                Cpf = "987654321AA",
                Email = "xunit@gmail.com",
                Password = "password",
                ProfessionalId = "AL123987",
                Postalcode = "29060701",
                State = "AL",
                City = "SomeCity",
                Photo = "null",
                CategoryAlias = "Tributário",
                Description = "xunit test description",
                Age = 999
            };

            // invalid cpf => bad request
            var result = await _controller.Delete(vm.Email, vm.Cpf, vm.Password);
            Assert.IsType<BadRequestObjectResult>(result);

            // invalid cpf => login error
            vm.Cpf = "98765432154";
            result = await _controller.Delete(vm.Email, vm.Cpf, vm.Password);
            var status = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(status.StatusCode, new StatusCodeResult(500).StatusCode);

            // valid
            vm.Cpf = "98765432155";
            result = await _controller.Delete(vm.Email, vm.Cpf, vm.Password);
            Assert.IsType<OkResult>(result);
        }

        [Theory]
        [InlineData(0, 10)]  // valid
        [InlineData(1, -10)] // invalid
        [InlineData(-1, 10)] // invalid
        public async Task GetPageTest(int skip, int take)
        {
            var result = await _controller.GetPage(skip, take);
            if (skip < 0 || take < 0)
            {
                Assert.IsType<BadRequestResult>(result);
                return;
            }
            var okResult = Assert.IsType<OkObjectResult>(result);
            var lawyers = Assert.IsAssignableFrom<IEnumerable<Lawyer>>(okResult.Value);
            Assert.Equal(take, lawyers.Count());            
        }

        [Theory]
        [InlineData(0, 10, null, null)]          // valid
        [InlineData(1, -10, null, null)]         // invalid
        [InlineData(-1, 10, null, null)]         // invalid
        [InlineData(0, 10, "Tributário", null)]  // valid
        [InlineData(0, 10, null, "ES")]          // valid
        [InlineData(0, 10, "Trabalhista", "ES")] // valid
        public async Task GetPageFilteredTest(int skip, int take, string? category, string? state)
        {
            var result = await _controller.GetPageFiltered(skip, take, category, state);
            if (skip < 0 || take < 0)
            {
                Assert.IsType<BadRequestResult>(result);
                return;
            }
            if (result is not OkObjectResult)
            {
                var status = Assert.IsType<StatusCodeResult>(result);
                Assert.Equal(status.StatusCode, new StatusCodeResult(500).StatusCode);
                return;
            }
            var okResult = Assert.IsType<OkObjectResult>(result);
            var lawyers = Assert.IsAssignableFrom<IEnumerable<Lawyer>>(okResult.Value);
            Assert.NotNull(lawyers);
        }

        [Theory]
        [InlineData("Tributário", null)]
        [InlineData(null, "ES")]
        [InlineData("Trabalhista", "ES")]
        public async Task GetFilteredTest(string? category, string? state)
        {
            var result = await _controller.GetFiltered(category, state);
            if (result is not OkObjectResult)
            {
                var status = Assert.IsType<StatusCodeResult>(result);
                Assert.Equal(status.StatusCode, new StatusCodeResult(500).StatusCode);
                return;
            }
            var okResult = Assert.IsType<OkObjectResult>(result);
            var lawyers = Assert.IsAssignableFrom<IEnumerable<Lawyer>>(okResult.Value);
            Assert.NotNull(lawyers);
        }

        [Theory]
        [InlineData("Tributário", null)]
        [InlineData(null, "ES")]
        [InlineData("Trabalhista", "ES")]
        public async Task GetFilteredCountTest(string? category, string? state)
        {
            var result = await _controller.GetAllFilteredCount(category, state);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var lawyersCount = Assert.IsAssignableFrom<int>(okResult.Value);
            Assert.True(lawyersCount >= 0);
        }

        [Theory]
        [InlineData("7a18bc81-a106-4843-84b7-f0baf91f067b")] // user exists
        [InlineData("7a18bc81-a106-4843-84b7-f0baf91f0671")] // user dont exists
        [InlineData("")] // invalid input
        public async Task GetByIdTest(string id)
        {
            var guid = Guid.NewGuid();
            if (!string.IsNullOrEmpty(id))
            {
                guid = Guid.Parse(id);
            }
            var result = await _controller.GetById(guid);
            if (result is not OkObjectResult)
            {
                var status = Assert.IsType<StatusCodeResult>(result);
                Assert.Equal(status.StatusCode, new StatusCodeResult(500).StatusCode);
                return;
            }
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Lawyer>(okResult.Value);
        }

        [Theory]
        [InlineData("7a18bc81-a106-4843-84b7-f0baf91f067b")] // user exists
        [InlineData("7a18bc81-a106-4843-84b7-f0baf91f0671")] // user dont exists
        public async Task GetCategoryTest(string id)
        {
            var result = await _controller.GetCategory(Guid.Parse(id));
            if (result is not OkObjectResult)
            {
                var status = Assert.IsType<StatusCodeResult>(result);
                Assert.Equal(status.StatusCode, new StatusCodeResult(500).StatusCode);
                return;
            }
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            Assert.True(!string.IsNullOrEmpty(okResult.Value.ToString()));
        }

        [Theory]
        [InlineData("gabrielzuany@gmail.com", "123546", "123")]     // correct
        [InlineData("gabrielzuany@gmail.com", "123546str", "123")]  // invalid cpf
        [InlineData("gabrielzuany@gmail.com", "123546", "aaaaa")]   // wrong credentials
        public async Task GetTest(string email, string cpf, string password)
        {
            var result = await _controller.Get(email, cpf, password);
            if (result is OkObjectResult okResult) 
            {
                Assert.IsType<Lawyer>(okResult.Value);
                return;
            }
            if (result is BadRequestObjectResult)
            {
                Assert.Equal("123546str", cpf);
                return;
            }
            var status = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(status.StatusCode, new StatusCodeResult(500).StatusCode);
        }
    }
}
