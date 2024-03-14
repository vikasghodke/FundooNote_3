using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using Newtonsoft.Json.Linq;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Hashing;
using RepoLayer.Interface;
using RepoLayer.JwtToken;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly FundoonoteContext1 _fundoonoteContext1;
        private readonly IConfiguration _config;
        private readonly Hash_password _hash_Password;
        

        public UserRL(FundoonoteContext1 _fundoonoteContext1, IConfiguration config, Hash_password hash_Password)
        {
            this._fundoonoteContext1 = _fundoonoteContext1;
            this._config = config;
            this._hash_Password = hash_Password;
            
        }

        // public UserEntity AddUserDetail(UserModel userModel)
        public UserModel AddUserDetail(UserModel userModel)
        {
            UserEntity entity = new UserEntity();
            entity.FirstName = userModel.FirstName;
            entity.LastName = userModel.LastName;
            entity.Email = userModel.Email;
            entity.Password = _hash_Password.HashPassword(userModel.Password);

            _fundoonoteContext1.Users.Add(entity);
            _fundoonoteContext1.SaveChanges();

            //return entity;
            return userModel;
        }
        public string UserLogin(UserLogin userLogin)
        {
            //UserEntity valid = null;

            UserEntity valid = _fundoonoteContext1.Users.FirstOrDefault(e => e.Email == userLogin.Email );
            Jwt_Token token = new Jwt_Token(_config);
            if (valid != null)
            {
                bool pass = _hash_Password.VerifyPassword(userLogin.Password, valid.Password);
                if (pass)
                {
                    // return "hello";
                    return token.GenerateToken(valid);
                }

            }
            return null;
        }
        public string GenerateToken(String emailId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
             new Claim(ClaimTypes.Email, emailId )
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> ForgetPass(string Email)
        {
            var user=_fundoonoteContext1.Users.FirstOrDefault(e=>e.Email == Email);
            Jwt_Token token = new Jwt_Token(_config);
            if (user!=null)
            {
                string _token = token.GenerateTokenReset(Email, user.id);

                var url= $"https://localhost:5001/api/Users/ForgetPass?token={_token}";

                EmailService service=new EmailService();
                await service.SendEmailAsync(Email, "Reset Password", url);
                return "Ok"; 
            }
            return null;
        } 
        public async Task<string> ResetPassword(string Password1,int userID)
        {
            var user=_fundoonoteContext1.Users.FirstOrDefault(e=>e.id==userID);
            Jwt_Token token=new Jwt_Token(_config);
            if(user!=null)
            {
                string result = _hash_Password.HashPassword(Password1);
                user.Password = result;
                _fundoonoteContext1.SaveChanges();
            }
            return Password1;

             
        }
        
       
    }
}















