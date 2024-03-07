using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Entity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.JwtToken

{
    public class Jwt_Token
    {



        private readonly IConfiguration _config;
        public Jwt_Token(IConfiguration config)

        {
            _config = config;

        }

        public string GenerateToken(UserEntity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
             new Claim(ClaimTypes.GivenName, user.FirstName ),
             new Claim(ClaimTypes.GivenName, user.LastName ),
             new Claim(ClaimTypes.Email, user.Email )


         };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        internal string GenerateToken(string email)
        {
            throw new NotImplementedException();
        }
    }

}