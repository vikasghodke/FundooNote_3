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

namespace RepoLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly FundoonoteContext1 _fundoonoteContext1;
        private readonly IConfiguration _config;
        private readonly Hash_password _hash_Password;
        private readonly IEmailService _emailService;

        public UserRL(FundoonoteContext1 _fundoonoteContext1, IConfiguration config, Hash_password hash_Password, EmailSevice emailSevice)
        {
            this._fundoonoteContext1 = _fundoonoteContext1;
            this._config = config;
            this._hash_Password = hash_Password;
            this._emailService = emailSevice;

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

            UserEntity valid = _fundoonoteContext1.Users.FirstOrDefault(e => e.Email == userLogin.Email);
            Jwt_Token token = new Jwt_Token(_config);
            if (valid != null)
            {
                bool pass = _hash_Password.VerifyPassword(userLogin.Password, valid.Password);
                if (pass)
                {
                    // return "hello";
                    return token.GenerateToken(valid);
                }

                return null;
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

        public string ForgetPass(string email)
        {
            UserEntity valid=_fundoonoteContext1.Users.FirstOrDefault(e=>e.Email== email);
            Jwt_Token token = new Jwt_Token(_config);
            if (valid != null)
            {
                return token.GenerateToken(valid);
                string resetLink = "https://example.com/resetpassword?token=" + token;
                _fundoonoteContext1.ForgetPass(token, resetLink);
            else
            {
                return null;
            }
            
        }
        

        
       








        /* public string ForgetPassword(Reset_PasswordModel reset_PasswordModel)
        {
            UserEntity valid = _fundoonoteContext1.Users.FirstOrDefault(e => e.Email == reset_PasswordModel.Email);
            Reset_Pas_Token token = new Reset_Pas_Token(_config);
            if (valid != null)
            {
                return token.GenerateToken1(valid);
            }
            return null;
        }
        public string GenereateToken1(string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
             new Claim(ClaimTypes.Email, email)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }*/
        /*public string ResetPassword(Reset_PasswordModel reset_PasswordModel)
        {
            var value = _fundoonoteContext1.Users.FirstOrDefault(e => e.Email == reset_PasswordModel.Email);
            Reset_Pas_Token toekn = new Reset_Pas_Token(_config);
            if (value != null)
            {
                ResetPasswordEntity entity = new ResetPasswordEntity();
                bool var = _hash_Password.VerifyPassword(reset_PasswordModel.Password, value.Password);
                if (var)
                {

                    entity.Passwrod = reset_PasswordModel.Password;
                    _fundoonoteContext1.SaveChanges();
                    
                }
                //return value.Password;                
            }
            //return value.Password;
            return value.Password;
            
        }*/
        /* public string ResetPassword(Reset_PasswordModel reset_PasswordModel)
         {
             var value = _fundoonoteContext1.Users.FirstOrDefault(e => e.Email == reset_PasswordModel.Email);
             ResetPasswordEntity entity = new ResetPasswordEntity();
             Reset_Pas_Token token1 = new Reset_Pas_Token(_config);
             bool var = _hash_Password.VerifyPassword(reset_PasswordModel.Password, value.Password);
             if (var)
             {
                 entity.Passwrod = reset_PasswordModel.Password;
                 _fundoonoteContext1.SaveChanges();
                 return token1.GenerateToken1(value);
             }
             return value.Password;

         }*/
        /* public string ResetPassword(Reset_PasswordModel reset_PasswordModel)
         {
             var user = _fundoonoteContext1.Users.FirstOrDefault(e => e.Email == reset_PasswordModel.Email);
             bool var=_hash_Password(reset_PasswordModel.Password, user.Password);

             if (user != null)
             {
                 ResetPasswordEntity entity = new ResetPasswordEntity();
                 entity.Passwrod = reset_PasswordModel.Password;

                 // _fundoonoteContext1.Users.Add(entity);
                 _fundoonoteContext1.SaveChanges();

             }
             return user.Password;
         }
 */
    }
}















