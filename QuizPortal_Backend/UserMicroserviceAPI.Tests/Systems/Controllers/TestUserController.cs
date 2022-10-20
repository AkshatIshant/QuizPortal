using AutoMapper;
using FluentAssertions;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroserviceAPI.Controllers;
using UserMicroserviceAPI.Models.Domain;
using UserMicroserviceAPI.Repositories.Interfaces;
using UserMicroserviceAPI.Services;
using UserMicroserviceAPI.Tests.MockData;

namespace UserMicroserviceAPI.Tests.Systems.Controllers
{
    public class TestUserController
    {
        [Fact]
        public async Task GetUserInfoAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var imapper = new Mock<IMapper>();
            var jwtauth = new Mock<JwtTokenHandler>();
            userRepository.Setup(x => x.GetUserInfoAsync("User1")).ReturnsAsync(UserMockData.GetUser());
            var sut = new UserController(userRepository.Object, imapper.Object, jwtauth.Object);
            //Act
            var result = await sut.GetUserInfoAsync("User1");
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetUserInfoAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var imapper = new Mock<IMapper>();
            var jwtauth = new Mock<JwtTokenHandler>();
            userRepository.Setup(x => x.GetUserInfoAsync("User90")).ReturnsAsync(UserMockData.NullUser());
            var sut = new UserController(userRepository.Object, imapper.Object, jwtauth.Object);
            //Act
            var result = await sut.GetUserInfoAsync("User90");
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var _mapper = new Mock<IMapper>();
            var _jwtAuthenticationManager = new Mock<JwtTokenHandler>();
            userRepository.Setup(x => x.DeleteUserAsync(5)).ReturnsAsync(UserMockData.GetUser());
            var sut = new UserController(userRepository.Object, _mapper.Object, _jwtAuthenticationManager.Object);

            //Act
            var result = await sut.DeleteUserAsync(5);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var _mapper = new Mock<IMapper>();
            var _jwtAuthenticationManager = new Mock<JwtTokenHandler>();
            userRepository.Setup(x => x.DeleteUserAsync(1)).ReturnsAsync(UserMockData.NullUser());
            var sut = new UserController(userRepository.Object, _mapper.Object, _jwtAuthenticationManager.Object);
            sut.ModelState.AddModelError("key", "bad request");
            //Act
            var result = await sut.DeleteUserAsync(1);
            ////    //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        //[Fact]
        public async Task RegisterUserAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var _mapper = new Mock<IMapper>();
            var _jwtAuthenticationManager = new Mock<JwtTokenHandler>();
            var user = UserMockData.GetUser();
            userRepository.Setup(x => x.RegisterUserAsync(user)).ReturnsAsync(UserMockData.GetUser());
            var sut = new UserController(userRepository.Object, _mapper.Object, _jwtAuthenticationManager.Object);

            //Act
            var result = await sut.RegisterUserAsync(user);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        //[Fact]
        public async Task RegisterUserAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var _mapper = new Mock<IMapper>();
            var _jwtAuthenticationManager = new Mock<JwtTokenHandler>();
            userRepository.Setup(x => x.RegisterUserAsync(UserMockData.WrongUser())).ReturnsAsync(UserMockData.WrongUser());
            var sut = new UserController(userRepository.Object, _mapper.Object, _jwtAuthenticationManager.Object);
            sut.ModelState.AddModelError("key", "Password confirmation failed");
            //Act
            var result = await sut.RegisterUserAsync(UserMockData.WrongUser());
            ////    //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        //[Fact]
        public async Task Authenticate_ShouldReturn200StatusCode()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var _mapper = new Mock<IMapper>();
            var _jwtAuthenticationManager = new Mock<JwtTokenHandler>();
            _jwtAuthenticationManager.Setup(x => x.GenerateToken(UserMockData.AuthUserReq())).Returns(UserMockData.AuthUserResp());
            var sut = new UserController(userRepository.Object, _mapper.Object, _jwtAuthenticationManager.Object);

            //Act
            var result = sut.LoginUser(UserMockData.AuthUserReq());

            // Assert
            result.GetType().Should().Be(typeof(AuthenticationResponse));

        }

        // [Fact]
        public async Task Authenticate_ShouldReturn401StatusCode()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var _mapper = new Mock<IMapper>();
            var _jwtAuthenticationManager = new Mock<JwtTokenHandler>();

            _jwtAuthenticationManager.Setup(x => x.GenerateToken(UserMockData.AuthUserReq())).Returns(UserMockData.AuthUserResp());

            var sut = new UserController(userRepository.Object, _mapper.Object, _jwtAuthenticationManager.Object);

            //Act
            var result = sut.LoginUser(UserMockData.NullRequest());
            // var result = sut.LoginUser(userLoginDetails);
            //Assert
            //result.GetType().Should().Be(typeof(AuthenticationResponse));
            result.GetType().Should().Be(typeof(UnauthorizedResult));
            //(result as UnauthorizedResult).StatusCode.Should().Be(401);
        }
    }
}
