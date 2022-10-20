using AutoMapper;
using ExamPortal.Tests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ResultMicroserviceAPI.Controllers;
using ResultMicroserviceAPI.Model.Domain;
using ResultMicroserviceAPI.Repository.Interfaces;
using Xunit;

namespace ExamPortal.Tests.Systems.Controllers
{
    public class TestResultController
    {
        [Fact]
        public async Task GetAllResAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var resultRepository = new Mock<IResultRepository>();
            var mapper = new Mock<IMapper>();

            resultRepository.Setup(x => x.GetAllResultsAsync()).ReturnsAsync(ResultMockData.GetResults());

            var sut = new ResultController(resultRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetAllResAsync();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task GetAllResultAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var resultRepository = new Mock<IResultRepository>();
            var mapper = new Mock<IMapper>();

            resultRepository.Setup(x => x.GetAllResultsAsync()).ReturnsAsync(ResultMockData.EmptyResultList());

            var sut = new ResultController(resultRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetAllResAsync();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }
        [Fact]
        public async Task GetAllResultByIdAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var resultRepository = new Mock<IResultRepository>();
            var mapper = new Mock<IMapper>();



            resultRepository.Setup(x => x.GetResultByIdAsync(1)).ReturnsAsync(ResultMockData.GetResultById());

            var sut = new ResultController(resultRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetResultByIdAsync(1);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task GetAllResultByIdAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var resultRepository = new Mock<IResultRepository>();
            var mapper = new Mock<IMapper>();


            resultRepository.Setup(x => x.GetResultByIdAsync(2)).ReturnsAsync(ResultMockData.EmptyResults());

            var sut = new ResultController(resultRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetResultByIdAsync(2);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task AddAsync_ShouldReturn201StatusCode()
        {
            //Arrange
            var resultRepository = new Mock<IResultRepository>();
            var mapper = new Mock<IMapper>();
            var result1 = new Mock<Result>();


            resultRepository.Setup(x => x.AddResultAsync(result1.Object)).ReturnsAsync(ResultMockData.AddResult());

            var sut = new ResultController(resultRepository.Object, mapper.Object);

            //Act
            var result = await sut.AddAsync(result1.Object);

            //Assert
            result.GetType().Should().Be(typeof(CreatedResult));
            (result as CreatedResult).StatusCode.Should().Be(201);

        }

        [Fact]

        public async Task AddAsync_ShouldReturn404StatusCode()
        {
            var resultRepository = new Mock<IResultRepository>();
            var mapper = new Mock<IMapper>();
            var resu = new Mock<Result>();
            


            var sut = new ResultController(resultRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");

            //Act
            var result = await sut.AddAsync( resu.Object);

            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }







    }
}
