using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuestionGroupMicroserviceAPI.Controllers;
using QuestionGroupMicroserviceAPI.Models.Domain;
using QuestionGroupMicroserviceAPI.Repositories.Interfaces;
using QuestionGroupMicroserviceAPI.Tests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuestionGroupMicroserviceAPI.Tests.Systems.Controllers
{
    public class TestQuestionGroupController
    {
        [Fact]
        public async Task GetTaskAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            questionGroupRepository.Setup(x => x.GetQuestionGroupsAsync()).ReturnsAsync(QuestionGroupMockData.GetQuestionGroups());
            var sut = new QuestionGroupController(questionGroupRepository.Object, _mapper.Object);
            //Act
            var result = await sut.GetQuestionGroupsAsync();
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetTaskAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            questionGroupRepository.Setup(x => x.GetQuestionGroupsAsync()).ReturnsAsync(QuestionGroupMockData.EmptyQuestionGroupsList());
            var sut = new QuestionGroupController(questionGroupRepository.Object, null);
            //Act
            var result = await sut.GetQuestionGroupsAsync();
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task GetQuestionGroupByIdAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionGroupReository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            questionGroupReository.Setup(x => x.GetQuestionGroupByIdAsync(1)).ReturnsAsync(QuestionGroupMockData.GetQuestionGroup());
            var sut = new QuestionGroupController(questionGroupReository.Object, _mapper.Object);
            //Act
            var result = await sut.GetQuestionGroupByIdAsync(1);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetQuestionGroupByIdAsync_ShouldReturn404StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            questionGroupRepository.Setup(x => x.GetQuestionGroupByIdAsync(2)).ReturnsAsync(QuestionGroupMockData.EmptyQuestionGroup());
            var sut = new QuestionGroupController(questionGroupRepository.Object, _mapper.Object);
            //Act
            var result = await sut.GetQuestionGroupByIdAsync(2);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task AddQuestionGroupAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            QuestionGroup questionGroup = QuestionGroupMockData.GetQuestionGroup();
            questionGroupRepository.Setup(x => x.AddQuestionGroupAsync(questionGroup)).ReturnsAsync(QuestionGroupMockData.GetQuestionGroup());
            var sut = new QuestionGroupController(questionGroupRepository.Object, _mapper.Object);
            //Act
            var result = await sut.AddQuestionGroupAsync(quesGrp: questionGroup);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task AddQuestionAsync_ShouldReturn404StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            QuestionGroup questionGroup = QuestionGroupMockData.EmptyQuestionGroup();
            questionGroupRepository.Setup(x => x.AddQuestionGroupAsync(questionGroup)).ReturnsAsync(QuestionGroupMockData.EmptyQuestionGroup());
            var sut = new QuestionGroupController(questionGroupRepository.Object, _mapper.Object);
            //Act
            var result = await sut.AddQuestionGroupAsync(questionGroup);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }
        [Fact]
        public async Task AddQuestionGroupAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            QuestionGroup questionGroup = QuestionGroupMockData.GetQuestionGroup();
           // questionGroupRepository.Setup(x => x.AddQuestionGroupAsync(questionGroup)).ReturnsAsync(QuestionGroupMockData);
            var sut = new QuestionGroupController(questionGroupRepository.Object, _mapper.Object);
            sut.ModelState.AddModelError("Error", "BadRequest");
            //Act
            var result = await sut.AddQuestionGroupAsync(questionGroup);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

       


        [Fact]
        public async Task DeleteQuestionGroupByIdAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            questionGroupRepository.Setup(x => x.DeleteQuestionGroupAsync(1)).ReturnsAsync(QuestionGroupMockData.GetQuestionGroup());
            var sut = new QuestionGroupController(questionGroupRepository.Object, _mapper.Object);
            //Act
            var result = await sut.DeleteQuestionGroupAsync(1);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteQuestionGroupByIdAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            questionGroupRepository.Setup(x => x.DeleteQuestionGroupAsync(5)).ReturnsAsync(QuestionGroupMockData.EmptyQuestionGroup());
            var sut = new QuestionGroupController(questionGroupRepository.Object, _mapper.Object);
            //Act
            var result = await sut.DeleteQuestionGroupAsync(5);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task UpdateQuestionGroupAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            QuestionGroup questionGroup = QuestionGroupMockData.GetQuestionGroup();
            questionGroupRepository.Setup(x => x.UpdateQuestionGroupAsync(1, questionGroup)).ReturnsAsync(QuestionGroupMockData.GetQuestionGroup());
            var sut = new QuestionGroupController(questionGroupRepository.Object, _mapper.Object);
            //Act
            var result = await sut.UpdateQuestionGroupASync(1, questionGroup);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task UpdateQuestionGroup_ShouldReturn400StatusCode()
        {
            //Arrange
            var questionRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            QuestionGroup question = QuestionGroupMockData.GetQuestionGroup();
            //questionRepository.Setup(x => x.UpdateQuestionAsync(5,question)).ReturnsAsync(QuestionMockData.UpdateQuestion());
            var sut = new QuestionGroupController(questionRepository.Object, _mapper.Object);
            sut.ModelState.AddModelError("Error", "BadRequest");
            //Act
            var result = await sut.UpdateQuestionGroupASync(5, question);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task UpdateQuestionGroupAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var questionGroupRepository = new Mock<IQuestionGroupRepository>();
            var _mapper = new Mock<IMapper>();
            QuestionGroup questionGroup = QuestionGroupMockData.EmptyQuestionGroup();
            questionGroupRepository.Setup(x => x.UpdateQuestionGroupAsync(5, questionGroup)).ReturnsAsync(QuestionGroupMockData.EmptyQuestionGroup());
            var sut = new QuestionGroupController(questionGroupRepository.Object, _mapper.Object);
            //Act
            var result = await sut.UpdateQuestionGroupASync(5, questionGroup);
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
    }
}
