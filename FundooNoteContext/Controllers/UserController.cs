using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using ModelLayer;
using RepoLayer.JwtToken;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooNoteContext.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string V = "not found";
        private readonly IUserBL userBL;
        private readonly IConfiguration _config;

        public UserController(IUserBL userBL, IConfiguration _config)
        {
            this.userBL = userBL;
            this._config = _config;
        }

        [HttpPost("Add")]
        public IActionResult AddUserDetail(UserModel userModel)
        {
            var result = userBL.AddUserDetail(userModel);
            if (result != null)
            {
                return Ok(new { Success = true, Message = "Added Sucessfully", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "something wet wrong" });
            }
        }
        /*[HttpGet]
        public IActionResult ViewDetail(string Email, string Password)
        {
            var result=userBL.ViewDetail(Email, Password);
            if(result != null)
            {
                return Ok(new { Success = true, Message = "Result", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "something wet wrong" });
            }
        }*/

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserLogin userlogin)
        {
            var result = userBL.UserLogin(userlogin);
            if (result != null)
            {
                return Ok(new { Success = true, Message = "Login sucessfully", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "something wet wrong" });
            }
        }

        [HttpPost]
        [Route("ForgetPass")]
        
        public  Task<string> ForgetPass(string Email)
        {
            
            var result =  userBL.ForgetPass(Email);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }
        [HttpPost("ResetPass")]
        public Task<string> ResetPassword(string token, string Password1)
        {
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience=true,
                ValidateLifetime=true,
                ValidateIssuerSigningKey=true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]))
            };

            SecurityToken validatedToekn;
            var principle=handler.ValidateToken(token, validationParameters, out validatedToekn);
            var userID = principle.FindFirstValue(ClaimTypes.NameIdentifier);
            int _userID=Convert.ToInt32(userID);
            var result=userBL.ResetPassword(Password1 , _userID);

            if(result!=null)
            {
                return result;       
                
            }
            else
            {
                return null;
            }

        }

    }

 }


    

