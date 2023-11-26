using AutoMapper;
using BL.Api.Authentication;
using BL.Api.V1.Controllers;
using BL.DAL;
using BL.Domain.Models;
using BL.UnitTests.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BL.UnitTests.Controllers.V1
{
    public class BlijvenLerenControllerTest
    {
        private readonly ILogger<BlijvenLerenController> _ilogger;
        private readonly IMapper _mapper;
        private readonly IBlijvenLerenRepository _blijvenLerenRepository;
        private readonly IJwtManager _jwtManager;
        private readonly BlijvenLerenController _blijvenLerenController;        
        private static readonly Resource _resource = new Resource() { Id = ConstantValues.FoundId };

        public BlijvenLerenControllerTest()
        {
            //Arrange
            _ilogger = new Mock<ILogger<BlijvenLerenController>>().Object;
            _mapper = new Mock<IMapper>().Object;
            _jwtManager = new Mock<IJwtManager>().Object;
            _blijvenLerenRepository = new CosmosDbFakeRepository();
            _blijvenLerenController = new BlijvenLerenController(_ilogger, _blijvenLerenRepository, _mapper, _jwtManager);
        }

        [Fact]
        public async Task Get_Resource_By_Id_Ok_Result()
        { 
            //Act
            var result = await _blijvenLerenController.GetResourceByIdAsync(ConstantValues.FoundId);

            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Resource>(viewResult.Value);
            Assert.IsType<Resource>(model);
            Assert.Equal(ConstantValues.FoundId, model.Id);
        }
    }
}
