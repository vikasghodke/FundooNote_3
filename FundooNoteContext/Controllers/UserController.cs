using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace FundooNoteContext.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost]
        public IActionResult AddUserDetail(UserModel userModel)
        {
            var result=userBL.AddUserDetail(userModel);
            if(result != null)
            {
                return Ok(new { Success = true, Message = "added sucessfully", Data = result });
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
                return Ok(new { Success = true, Message = "added sucessfully", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "something wet wrong" });
            }
        }


    }
}
