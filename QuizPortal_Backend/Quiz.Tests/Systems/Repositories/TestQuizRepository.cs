using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.Repositories;
using QuizAPI.Tests.MockData;
using QuizAPI.Models.Domain;

namespace ExamPortal.Tests.Systems.Repositories
{
    public class TestQuizRepository : IDisposable
    {
        private readonly QuizPortalDbContext context;
        private object id;

        public TestQuizRepository()
        {
            var options = new DbContextOptionsBuilder<QuizPortalDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new QuizPortalDbContext(options);
            context.Database.EnsureCreated();
        }
        [Fact]
        public async Task GetQuizAsync_ShouldReturnQuizList()
        {
            //Arrange
            context.Quizs.AddRange(QuizMockData.GetQuizs());
            context.SaveChanges();
            var sut = new QuizRepository(context);
            //Act
            var result = await sut.GetQuizesAsync();
            //assert
            result.Should().HaveCount(QuizMockData.GetQuizs().Count);

        }
        [Fact]
        public async Task GetQuizByIdAsync_ShouldReturnQuizList()
        {
            //Arrange
            context.Quizs.AddRange(QuizMockData.GetQuizs());
            context.SaveChanges();
            var sut = new QuizRepository(context);
            //Act
            var result = await sut.GetQuizByIdAsync(1);
            //assert
            result.GetType().Should().NotBeNull();
        }
        [Fact]
        public async Task AddQuizAsync_ShouldReturnQuiz()
        {
            context.Quizs.AddRange(QuizMockData.GetQuizs());
            context.SaveChanges();
            var sut = new QuizRepository(context);
            Quiz quiz = QuizMockData.GetQuizByIdAsync();
            //Act
            var result = await sut.AddQuizAsync(quiz);
            //assert
            result.GetType().Should().Be(typeof(Quiz));
        }

        [Fact]
        public async Task DeleteQuizAsync_ShouldReturnQuiz()
        {
            context.Quizs.AddRange(QuizMockData.GetQuizs());
            context.SaveChanges();
            var sut = new QuizRepository(context);
            //Act
            var result = await sut.DeleteQuizAsync(3);
            //assert
            result.GetType().Should().Be(typeof(Quiz));
        }
        [Fact]
        public async Task UpdateQuizAsync_ShouldReturnQuiz()
        {
            context.Quizs.AddRange(QuizMockData.GetQuizs());
            context.SaveChanges();
            var sut = new QuizRepository(context);
            var quizs = QuizMockData.GetQuizs();
            Quiz quiz = quizs[0];
            //Act
            var result = await sut.UpdateQuizAsync(1, quiz);
            //assert
            result.GetType().Should().Be(typeof(Quiz));

        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
