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
using UserMicroserviceAPI.Repositories;
using UserMicroserviceAPI.Tests.MockData;

namespace UserMicroserviceAPI.Tests.Systems.Repositories
{
    public class TestJwtAuthenticationManager : IDisposable
    {
        private readonly UserMicroserviceAPIDB context;
        public TestJwtAuthenticationManager()
        {
            var options = new DbContextOptionsBuilder<UserMicroserviceAPIDB>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new UserMicroserviceAPIDB(options);
            context.Database.EnsureCreated();
        }
        // [Fact]
        public async Task Authenticate_ShouldReturnToken()
        {
            //Arrange
            context.Users.AddRange(UserMockData.GetUsers());
            var userRepository = new Mock<UserRepository>(context);
            string key = Guid.NewGuid().ToString();
            context.SaveChanges();
            // var sut = new JwtAuthenticationManager(key, userRepository.Object);
            //Act
            // var result = sut.Authenticate("User1", "Password1");
            //assert
            // result.GetType().Should().Be(typeof(String));
        }

        // [Fact]
        public async Task Authenticate_ShouldReturnNull()
        {

            //Arrange
            context.Users.AddRange(UserMockData.GetUsers());
            var userRepository = new Mock<UserRepository>(context);
            string key = Guid.NewGuid().ToString();
            context.SaveChanges();
            //var sut = new JwtAuthenticationManager(key, userRepository.Object);
            //Act
            //var result = sut.Authenticate("User5", "Password5");
            //assert
            // result.Should().BeNull();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
