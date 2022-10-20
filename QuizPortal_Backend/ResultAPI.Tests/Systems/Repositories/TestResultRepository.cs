using ExamPortal.Tests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResultMicroserviceAPI.Data;

using ResultMicroserviceAPI.Model.Domain;
using ResultMicroserviceAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortal.Tests.Systems.Repositories
{
    public class TestResultRepository : IDisposable
    {
        private readonly ResultDbContext context;

        public TestResultRepository()
        {
            var options = new DbContextOptionsBuilder<
                ResultDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            context = new ResultDbContext(options);
            context.Database.EnsureCreated();
        }



        [Fact]
        public async Task GetAllResultsAsync_ShouldReturnAllResult()
        {
            //Arrange

            context.Results.AddRange(ResultMockData.GetResults());
            context.SaveChanges();


            
            var sut = new ResultRepository(context);
            
            //Act
            var result = await sut.GetAllResultsAsync();

            //Assert
            result.Should().HaveCount(ResultMockData.GetResults().Count);
        }

       

        [Fact]

        public async Task GetAllResultByIdAsync_ShouldReturnResultById()
        {
            //Arrange

            context.Results.AddRange(ResultMockData.GetResultById());
            context.SaveChanges();



            var sut = new ResultRepository(context);
            int id = 1;
            //Act
            var result = await sut.GetResultByIdAsync(1);

            //Assert
            result.GetType().Should().NotBeNull();
        }

        [Fact]

        public async Task AddAsync_ShouldReturnResult()
        {
            //Arrange

            context.Results.AddRange(ResultMockData.GetResults());
            context.SaveChanges();



            var sut = new ResultRepository(context);
            Result result = ResultMockData.AddResult();

            //Act
            var res = await sut.AddResultAsync( result);

            //Assert
            res.GetType().Should().Be(typeof(Result));
        }



        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

       
    }
}
