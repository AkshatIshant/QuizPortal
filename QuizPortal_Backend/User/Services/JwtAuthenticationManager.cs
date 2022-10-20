using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserMicroserviceAPI.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using UserMicroserviceAPI.Services;
using System.Collections;

namespace ExamPortal.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private Microsoft.IdentityModel.Tokens.SecurityToken _token;
        private readonly string key;
        public readonly IUserRepository userRepository;
        public JwtAuthenticationManager(string key, IUserRepository userRepository)
        {
            this.key = key;
            this.userRepository = userRepository;   
        }

        private readonly IDictionary<string, string> adminUsers =
           new Dictionary<string, string>
           {
                {"admin1","password1"},
                {"admin2", "password2"}
           };

        public string Authenticate(string username, string password)
        {
            var users = userRepository.GetUsers();
            if (!users.Any(u => u.UserName== username && u.Password == password) && !adminUsers.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); 
        }
    }
}
