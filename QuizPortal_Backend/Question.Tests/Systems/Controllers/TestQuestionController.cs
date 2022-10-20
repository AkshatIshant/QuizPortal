using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuestionAPI.Tests.MockData;
using QuestionMicroserviceAPI.Controllers;
using QuestionMicroserviceAPI.Models.Domain;
using QuestionMicroserviceAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAPI.Tests.Systems.Controllers
{
    public class TestQuestionController
    {
        private Question question;

        [Fact]
        public async Task GetTaskAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            questionRepository.Setup(x => x.GetQuestionsAsync()).ReturnsAsync(QuestionMockData.GetQuestions());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            //Act
            var result = await sut.GetQuestionsAsync();
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetTaskAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            questionRepository.Setup(x => x.GetQuestionsAsync()).ReturnsAsync(QuestionMockData.EmptyQuestionsList());
            var sut = new QuestionController(questionRepository.Object, null);
            //Act
            var result = await sut.GetQuestionsAsync();
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task GetQuestionByIdAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            questionRepository.Setup(x => x.GetQuestionByIdAsync(1)).ReturnsAsync(QuestionMockData.GetQuestion());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            //Act
            var result = await sut.GetQuestionByIdAsync(1);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetQuestionByIdAsync_ShouldReturn404StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            questionRepository.Setup(x => x.GetQuestionByIdAsync(2)).ReturnsAsync(QuestionMockData.EmptyQuestion());
            var sut = new QuestionController(questionRepository.Object,_mapper.Object);
            //Act
            var result = await sut.GetQuestionByIdAsync(2);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task AddQuestionAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            Question question = QuestionMockData.GetQuestion();
            questionRepository.Setup(x => x.AddQuestionAsync(question)).ReturnsAsync(QuestionMockData.GetQuestion());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            //Act
            var result = await sut.AddQuestionAsync(ques: question);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task AddQuestionAsync_ShouldReturn404StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            Question question = QuestionMockData.EmptyQuestion();
            questionRepository.Setup(x => x.AddQuestionAsync(question)).ReturnsAsync(QuestionMockData.EmptyQuestion());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            //Act
            var result = await sut.AddQuestionAsync(question);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task AddQuestionAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            Question question = QuestionMockData.GetQuestion();
            //questionRepository.Setup(x => x.UpdateQuestionAsync(5,question)).ReturnsAsync(QuestionMockData.UpdateQuestion());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            sut.ModelState.AddModelError("Error", "BadRequest");
            //Act
            var result = await sut.AddQuestionAsync(question);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteQuestionByIdAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            questionRepository.Setup(x => x.DeleteQuestionAsync(1)).ReturnsAsync(QuestionMockData.GetQuestion());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            //Act
            var result = await sut.DeleteQuestionAsync(1);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteQuestionByIdAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            questionRepository.Setup(x => x.DeleteQuestionAsync(5)).ReturnsAsync(QuestionMockData.EmptyQuestion());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            //Act
            var result = await sut.DeleteQuestionAsync(5);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task UpdateQuestionAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            Question question = QuestionMockData.GetQuestion();
            questionRepository.Setup(x => x.UpdateQuestionAsync(1,question)).ReturnsAsync(QuestionMockData.GetQuestion());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            //Act
            var result = await sut.UpdateQuestionASync(1,question);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task UpdateQuestion_ShouldReturn400StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            Question question = QuestionMockData.GetQuestion();
            //questionRepository.Setup(x => x.UpdateQuestionAsync(5,question)).ReturnsAsync(QuestionMockData.UpdateQuestion());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            sut.ModelState.AddModelError("Error", "BadRequest");
            //Act
            var result = await sut.UpdateQuestionASync(5, question);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        
        [Fact]
        public async Task UpdateQuestionAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionRepository>();
            var _mapper = new Mock<IMapper>();
            Question question = QuestionMockData.EmptyQuestion();
            questionRepository.Setup(x => x.UpdateQuestionAsync(5,question)).ReturnsAsync(QuestionMockData.EmptyQuestion());
            var sut = new QuestionController(questionRepository.Object, _mapper.Object);
            //Act
            var result = await sut.UpdateQuestionASync(5,question);
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

    }
}
