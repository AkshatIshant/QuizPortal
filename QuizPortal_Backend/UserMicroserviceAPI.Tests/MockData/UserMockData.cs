using JwtAuthenticationManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UserMicroserviceAPI.Models.Domain;
using UserMicroserviceAPI.Models.DTO;

namespace UserMicroserviceAPI.Tests.MockData
{
    public class UserMockData
    {
        public static User GetUser()
        {
            var user = new User()
            {
                Id=5,
                UserName = "User1",
                Password = "Password1",
                ConfirmPassword = "Password1",
                FirstName = "Name1",
                LastName = "Last1",
                Email = "user1@c.com",
                Contact = 7638273222,
                Role = "Candidate",

            };
            return user;
        }

        public static AuthenticationRequest AuthUserReq()
        {
            var user = new AuthenticationRequest()
            {
                UserName = "Riya01",
                Password = "rs66&5",



            };
            return user;
        }
        public static AuthenticationResponse AuthUserResp()
        {
            var user = new AuthenticationResponse()
            {
                UserName = "Riya01",
                JwtToken = "rs66&5vjhvgjhvhfvu",
                ExpiresIn = 6564



            };
            return user;
        }

    
        public static AuthenticationRequest NullRequest() { return null; }



        public static User WrongUser()
        {
            var user = new User()
            {
                Id=5,
                UserName = "User1",
                Password = "Password",
                ConfirmPassword = "Password1",
                FirstName = "Name1",
                LastName = "Last1",
                Email = "user1@c.com",
                Contact = 7638273222,
                Role = "Candidate",

            };
            return user;
        }

        public static User EmptyUser()
        {
            return new User();
        }

        public static List<User> GetUsers()
        {
            return new List<User>()
            {
               new User() {
                Id = 1,
                UserName = "User1",
                Password = "Password1",
                ConfirmPassword = "Password1",
                FirstName = "Name1",
                LastName = "Last1",
                Email = "user1@c.com",
                Contact = 7638273222,
                Role = "Admin",} ,
               new User() {
                Id = 2,
                UserName = "User2",
                Password = "Password2",
                ConfirmPassword = "Password2",
                FirstName = "Name2",
                LastName = "Last2",
                Email = "user2@c.com",
                Contact = 7638273222,
                Role = "Admin",},
               new User(){
                Id = 3,
                UserName = "User3",
                Password = "Password3",
                ConfirmPassword = "Password3",
                FirstName = "Name3",
                LastName = "Last3",
                Email = "user3@c.com",
                Contact = 7638273222,
                Role = "Admin"
                }
            };
        }

        public static User NullUser()
        {
            return null;
        }

        public static LoginUserDto LoginUser()
        {
            return new LoginUserDto()
            {
                UserName = "Riya01",
                Password = "rs66&5"
            };
        }

        public static string GetToken()
        {
            return "Token";
        }
    }
}

