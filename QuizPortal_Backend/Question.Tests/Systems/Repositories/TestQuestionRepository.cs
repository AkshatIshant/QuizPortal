using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuestionAPI.Tests.MockData;
using QuestionMicroserviceAPI.Data;
using QuestionMicroserviceAPI.Models.Domain;
using QuestionMicroserviceAPI.Repositories;


namespace QuestionAPI.Tests.Systems.Repositories
{
    public class TestQuestionRepository : IDisposable
    {
        private readonly QuestionDbContext context;
        public TestQuestionRepository()
        {
            var options = new DbContextOptionsBuilder<QuestionDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new QuestionDbContext(options);
            context.Database.EnsureCreated();
        }
        [Fact]
        public async Task GetQuestionsAsync_ShouldReturnQuestionList()
        {
            //Arrange
            context.Questions.AddRange(QuestionMockData.GetQuestions());
            context.SaveChanges();
            var sut = new QuestionRepository(context);
            //Act
            var result = await sut.GetQuestionsAsync();
            //assert
            result.Should().HaveCount(QuestionMockData.GetQuestions().Count);
        }

        [Fact]
        public async Task GetQuestionByIdAsync_ShouldReturnQuestion()
        {
            //Arrange
            context.Questions.AddRange(QuestionMockData.GetQuestion());
            context.SaveChanges();
            var sut = new QuestionRepository(context);
            //Act
            var result = await sut.GetQuestionByIdAsync(1);
            //assert
            result.GetType().Should().NotBeNull();
        }

        [Fact]
        public async Task AddQuestionAsync_ShouldReturnQuestion() 
        {
            context.Questions.AddRange(QuestionMockData.GetQuestions());
            context.SaveChanges();
            var sut = new QuestionRepository(context);
            Question question = QuestionMockData.GetQuestion(); 
            //Act
            var result = await sut.AddQuestionAsync(question);
            //assert
            result.GetType().Should().Be(typeof(Question));
        }

        [Fact]
        public async Task DeleteQuestionAsync_ShouldReturnQuestion()
        {
            context.Questions.AddRange(QuestionMockData.GetQuestions());
            context.SaveChanges();
            var sut = new QuestionRepository(context);
            //Act
            var result = await sut.DeleteQuestionAsync(3);
            //assert
            result.GetType().Should().Be(typeof(Question));
        }
        [Fact]
        public async Task UpdateQuestionAsync_ShouldReturnQuestion() 
        {
            context.Questions.AddRange(QuestionMockData.GetQuestions());
            context.SaveChanges();
            var sut = new QuestionRepository(context);
            var questions = QuestionMockData.GetQuestions();
            Question question = questions[0];
            //Act
            var result = await sut.UpdateQuestionAsync(1, question);
            //assert
            result.GetType().Should().Be(typeof(Question));
             
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
        // check time
    }
}
