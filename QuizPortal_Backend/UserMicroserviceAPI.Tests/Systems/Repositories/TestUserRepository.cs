using ExamPortal.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroserviceAPI.Data;
using UserMicroserviceAPI.Models.Domain;
using UserMicroserviceAPI.Repositories;
using UserMicroserviceAPI.Tests.MockData;

namespace UserMicroserviceAPI.Tests.Systems.Repositories
{
    public class TestUserRepository : IDisposable
    {
        private readonly UserMicroserviceAPIDB context;
        public TestUserRepository()
        {
            var options = new DbContextOptionsBuilder<UserMicroserviceAPIDB>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new UserMicroserviceAPIDB(options);
            context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetUserInfoAsync_ShouldReturnUser()
        {

            //Arrange
            context.Users.AddRange(UserMockData.GetUser());
            context.SaveChanges();
            var sut = new UserRepository(context);
            //Act
            var result = await sut.GetUserInfoAsync("User1");
            //assert
            result.Should().NotBeNull();

        }

        [Fact]
        public async Task RegisterUserInfoAsync_ShouldReturnUser()
        {
            //Arrange
            context.Users.AddRange(UserMockData.GetUsers());
            context.SaveChanges();
            var sut = new UserRepository(context);
            ////Act
            var result = await sut.RegisterUserAsync(UserMockData.GetUser());
            ////Assert
            result.GetType().Should().Be(typeof(User));
          
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldReturnUser()
        {
            //Arrange
            context.Users.AddRange(UserMockData.GetUsers());
            context.SaveChanges();
            var sut = new UserRepository(context);
            //Act
            var result = await sut.DeleteUserAsync(2);
            //Assert
            result.GetType().Should().Be(typeof(User));
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldReturnNull()
        {
            //Arrange
            context.Users.AddRange(UserMockData.GetUsers());
            context.SaveChanges();
            var sut = new UserRepository(context);
            //Act
            var result = await sut.DeleteUserAsync(6);
            //Assert
            result.Should().BeNull();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
