using AutoMapper;
using UserMicroserviceAPI.Models.Dto;
using UserMicroserviceAPI.Repositories;
using UserMicroserviceAPI.Repositories.Interfaces;
using UserMicroserviceAPI.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using UserMicroserviceAPI.Services;
using UserMicroserviceAPI.Models.DTO;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;

namespace UserMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository userRepository;
        public readonly IMapper mapper;
        private readonly JwtTokenHandler jwtAuthenticationManager;
        public UserController(IUserRepository _userRepository, IMapper _mapper, JwtTokenHandler jwtAuthenticationManager)
        {
            userRepository = _userRepository;
            mapper = _mapper;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost("Authenticate")]
        public ActionResult<AuthenticationResponse> LoginUser([FromBody] AuthenticationRequest _user)
        {

            var authenticationResponse = this.jwtAuthenticationManager.GenerateToken(_user);
            if (authenticationResponse == null)
            {
                return Unauthorized();
            }
            return authenticationResponse;

            //var token = jwtAuthenticationManager.Authenticate(_user.UserName, _user.Password);
            //if (token == null)
            //{
            //    return Unauthorized();
            //}
            //return Ok(token);
        }

        [HttpDelete("id")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await userRepository.DeleteUserAsync(id);
            if (user == null)
            {
                return BadRequest(false);
            }
            else 
            {
                var userDto = mapper.Map<UserDto>(user);
                return Ok(true);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Candidate")]
        public async Task<IActionResult> RegisterUserAsync(User user)
        {
            var users = userRepository.GetUsers();
            if (users.Any(x => x.UserName == user.UserName))
            {
                return BadRequest("This username already exists");
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (user.Password != user.ConfirmPassword)
            {
                return BadRequest("Password confirmation failed");
            }
            else if (user.Contact.ToString().Length != 10)
            {
                return BadRequest("The contact number is invalid");
            }
            else
            {
                var userModel = new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    ConfirmPassword = user.ConfirmPassword,
                    Role = "Candidate",
                    FirstName= user.FirstName,
                    LastName= user.LastName,
                    Email= user.Email,
                    Contact= user.Contact,
                };
                
                user = await userRepository.RegisterUserAsync(userModel);
                var userDto = mapper.Map<UserDto>(user);
                return Ok(userDto);

            }
        }

        [HttpGet("id")]
        [Authorize(Roles = "Admin,Candidate")]
        public async Task<IActionResult> GetUserInfoAsync(string name)
        {
            var user = await userRepository.GetUserInfoAsync(name);
            if(user == null)
            {
                return NoContent();
            }
            var userDto = mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Candidate")]
        public  ActionResult<List<User>> GetAllUsers()
        {
            var users =  userRepository.GetUsers();
            return Ok(users);
        }


        [HttpGet("Validate")]
        public ActionResult<List<User>> GetAllUsersForValidation()
        {
            var users = userRepository.GetUsers();
            return Ok(users);
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserAsync(User user)
        {
            var users = userRepository.GetUsers();
            if (users.Any(x => x.UserName == user.UserName))
            {
                return BadRequest("This username already exists");
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (user.Password != user.ConfirmPassword)
            {
                return BadRequest("Password confirmation failed");
            }
            else if (user.Contact.ToString().Length != 10)
            {
                return BadRequest("The contact number is invalid");
            }
            else
            {
                var userModel = new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    ConfirmPassword = user.ConfirmPassword,
                    Role = user.Role,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Contact = user.Contact,
                };



                user = await userRepository.RegisterUserAsync(userModel);
                var userDto = mapper.Map<UserDto>(user);
                return Ok(userDto);



            }
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserAsync(int id, User _user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var user = await userRepository.UpdateUserAsync(id, _user);
                var userDto = mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
        }
    }
}


