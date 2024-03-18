using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System;
using System.Collections.Generic;
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
            int _userID = Convert.ToInt32(userID);
            var result = collaboratorBL.AddCollab(collaboratorModel, _userID);
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
        [Authorize]
        public List<string> ViewCollab(int _noteID)
        {
            string userID = User.FindFirstValue("UserID");
            int _userID = Convert.ToInt32(userID);

            var result = collaboratorBL.ViewCollab(_userID, _noteID);
            //var response = new List<string>();
            if (result != null)
            {
                //return Ok(new { Success = true, Message = "Addes Successfully", result}); 
                return result;
            }
            else
            {
                return new List<string>();

            }
            // return response;
        }
    }
}

