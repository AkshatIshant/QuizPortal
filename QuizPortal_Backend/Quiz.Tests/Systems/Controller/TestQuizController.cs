using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

using Moq;
using QuizAPI.Controllers;
using QuizAPI.Models.Domain;
using QuizAPI.Repositories.Interfaces;
using QuizAPI.Tests.MockData;

namespace QuizAPI.Tests.Systems.Controllers
{
    public class TestQuizController
    {

        [Fact]
        public async Task GetTaskAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>();
            quizRepository.Setup(x => x.GetQuizesAsync()).ReturnsAsync(QuizMockData.GetQuizs());
            var sut = new QuizController(quizRepository.Object, mapper.Object);
            //Act
            var result = await sut.GetQuizesAsync();
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetTaskAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>(); //extra_Add
            quizRepository.Setup(x => x.GetQuizesAsync()).ReturnsAsync(QuizMockData.EmptyQuizList());
            var sut = new QuizController(quizRepository.Object, null);
            //Act
            var result = await sut.GetQuizesAsync();
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task GetQuizByIdAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>();
            quizRepository.Setup(x => x.GetQuizByIdAsync(1)).ReturnsAsync(QuizMockData.GetQuizByIdAsync());
            var sut = new QuizController(quizRepository.Object, mapper.Object);
            //Act
            var result = await sut.GetQuizByIdAsync(1);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetQuizByIdAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>();
            quizRepository.Setup(x => x.GetQuizByIdAsync(2)).ReturnsAsync(QuizMockData.EmptyQuiz());
            var sut = new QuizController(quizRepository.Object, mapper.Object);
            //Act
            var result = await sut.GetQuizByIdAsync(2);
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task DeleteQuizAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>();
            quizRepository.Setup(x => x.DeleteQuizAsync(1)).ReturnsAsync(QuizMockData.GetQuizByIdAsync());
            var sut = new QuizController(quizRepository.Object, mapper.Object);
            //Act
            var result = await sut.DeleteQuizAsync(1);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task DeleteQuizAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>();
            quizRepository.Setup(x => x.DeleteQuizAsync(5)).ReturnsAsync(QuizMockData.EmptyQuiz());
            var sut = new QuizController(quizRepository.Object, mapper.Object);
            //Act
            var result = await sut.DeleteQuizAsync(5);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task UpdateQuizAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>();
            Quiz quiz = QuizMockData.GetQuizByIdAsync();
            quizRepository.Setup(x => x.UpdateQuizAsync(1, quiz)).ReturnsAsync(QuizMockData.EmptyQuiz());
            var sut = new QuizController(quizRepository.Object, mapper.Object);
            //Act
            var result = await sut.UpdateQuizAsync(1, quiz);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task UpdateQuizAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>();
            var quiz = QuizMockData.EmptyQuiz();
            //quizRepository.Setup(x => x.UpdateQuizAsync(5,quiz)).ReturnsAsync(QuizMockData.EmptyQuiz());
            var sut = new QuizController(quizRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("key", "bad request");
            //Act
            var result = await sut.UpdateQuizAsync(5, quiz);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task AddQuizAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>();
            var quiz = QuizMockData.GetQuizByIdAsync();
            quizRepository.Setup(x => x.AddQuizAsync(quiz)).ReturnsAsync(QuizMockData.GetQuizByIdAsync());
            var sut = new QuizController(quizRepository.Object, mapper.Object);
            //Act
            var result = await sut.AddQuizAsync(quiz);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task AddQuizAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var quizRepository = new Mock<IQuizRepository>();
            var mapper = new Mock<IMapper>();
            var quiz = QuizMockData.EmptyQuiz();
            var sut = new QuizController(quizRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Error", "No Content Found");

            //Act
            var result = await sut.AddQuizAsync(quiz);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

    }
}
