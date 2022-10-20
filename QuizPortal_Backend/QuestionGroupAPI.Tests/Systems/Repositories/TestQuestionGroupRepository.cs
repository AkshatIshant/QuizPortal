using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuestionGroupMicroserviceAPI.Data;
using QuestionGroupMicroserviceAPI.Models.Domain;
using QuestionGroupMicroserviceAPI.Repositories;
using QuestionGroupMicroserviceAPI.Tests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuestionGroupMicroserviceAPI.Tests.Systems.Repositories
{
    public class TestQuestionGroupRepository:IDisposable
    {
        private readonly QuestionGroupDbContext context;
        public TestQuestionGroupRepository()
        {
            var options = new DbContextOptionsBuilder<QuestionGroupDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new QuestionGroupDbContext(options);
            context.Database.EnsureCreated();
        }
        [Fact]
        public async Task GetTaskAsync_ShouldReturnQuestionGroupList()
        {
            //Arrange
            context.QuestionGroups.AddRange(QuestionGroupMockData.GetQuestionGroups());
            context.SaveChanges();
            var sut = new QuestionGroupRepository(context);
            //Act
            var result = await sut.GetQuestionGroupsAsync();
            //assert
            result.Should().HaveCount(QuestionGroupMockData.GetQuestionGroups().Count);
        }

        [Fact]
        public async Task GetQuestionGroupByIdTaskAsync_ShouldReturnQuestionGroup()
        {
            //Arrange
            context.QuestionGroups.AddRange(QuestionGroupMockData.GetQuestionGroup());
            context.SaveChanges();
            var sut = new QuestionGroupRepository(context);
            //Act
            var result = await sut.GetQuestionGroupByIdAsync(1);
            //assert
            result.GetType().Should().NotBeNull();
        }

        [Fact]
        public async Task AddQuestionGroupAsync_ShouldReturnQuestion()
        {
            context.QuestionGroups.AddRange(QuestionGroupMockData.GetQuestionGroups());
            context.SaveChanges();
            var sut = new QuestionGroupRepository(context);
            QuestionGroup questionGroup = QuestionGroupMockData.GetQuestionGroup();
            //Act
            var result = await sut.AddQuestionGroupAsync(questionGroup);
            //assert
            result.GetType().Should().Be(typeof(QuestionGroup));
        }

        [Fact]
        public async Task DeleteQuestionGroupAsync_ShouldReturnQuestion()
        {
            context.QuestionGroups.AddRange(QuestionGroupMockData.GetQuestionGroups());
            context.SaveChanges();
            var sut = new QuestionGroupRepository(context);
            //Act
            var result = await sut.DeleteQuestionGroupAsync(3);
            //assert
            result.GetType().Should().Be(typeof(QuestionGroup));
        }
        [Fact]
        public async Task UpdateQuestionGroupAsync_ShouldReturnQuestion()
        {
            context.QuestionGroups.AddRange(QuestionGroupMockData.GetQuestionGroups());
            context.SaveChanges();
            var sut = new QuestionGroupRepository(context);
            var questionGroups = QuestionGroupMockData. GetQuestionGroup();
            QuestionGroup questionGroup = questionGroups;
            //Act
            var result = await sut.UpdateQuestionGroupAsync(1, questionGroup);
            //assert
            result.GetType().Should().Be(typeof(QuestionGroup));

        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
