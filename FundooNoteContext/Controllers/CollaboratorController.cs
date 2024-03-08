using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System;
using System.Security.Claims;

namespace FundooNoteContext.Controllers
{
    [Route("api/collaborator")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private readonly INoteBL noteBL;
        private readonly ICollaboratorBL collaboratorBL;

        public CollaboratorController(INoteBL noteBL, ICollaboratorBL collaboratorBL)
        {
            this.noteBL = noteBL;
            this.collaboratorBL = collaboratorBL;
        }
        [HttpPost("Add")]
        public IActionResult AddCollab(CollaboratorModel collaboratorModel)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int _userID= Convert.ToInt32(userID);
            var result = collaboratorBL.AddCollab(collaboratorModel,_userID);
            if (result != null)
            {
                return Ok(new { Success = true, Message = "Addes Successfully", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Something went wrong" });
            }

        }
        [HttpGet("View")]
        public IActionResult ViewCollab(int _noteID)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int _userID= Convert.ToInt32(userID);
            var res1=collaboratorBL.ViewCollab( _userID, _noteID);
            if(res1 != null  && res1.Count > 0)
            {
                return Ok(new { Success = true, Message="Sucess", Data= res1 });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Something Went Wrong" });
            }
        }
    }
}
