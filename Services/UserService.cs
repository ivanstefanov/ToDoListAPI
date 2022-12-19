using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaymentsAPI.Services
{
    public class UserService: IUserService
    {
        public string GetToken(string username, string password, string role)
        {
            //todo: logic to check if the username and password are correct and if so, login the user

            var secret = Environment.GetEnvironmentVariable("JWT_SECRET");            
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "Ivan"),                    
                    new Claim(ClaimTypes.Role, role)
                    //new Claim(ClaimTypes.Role, "customer")
                    //new Claim(ClaimTypes.Role, "admin")
                }),

                Expires = DateTime.UtcNow.AddMinutes(5),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encodedToken = tokenHandler.WriteToken(token);            

            return encodedToken;
        }
    }
}
