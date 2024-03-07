﻿using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System;
using System.Security.Claims;

namespace FundooNoteContext.Controllers
{
    [Route("api/Notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteBL _noteBL;

        public NoteController(INoteBL noteBL)
        {
            this._noteBL = noteBL;
        }

        [HttpPost("AddNote")]
        [Authorize]
        public IActionResult AddNote(NoteModel noteModel)
        {

            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int _userID = Convert.ToInt32(userID);

            var result = _noteBL.AddNote(noteModel, _userID);

            if (result != null)
            {
                return Ok(new { Success = true, Message = "added sucessfully", Data = result });
            }
            else
            {

                return BadRequest(new { Success = false, Message = "something wet wrong" });
            }
        }
        [HttpPut("UpdateNote")]
        [Authorize]

        public IActionResult EditNote1(int _userID, EditNote editNote)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int __userID = Convert.ToInt32(userID);
            var result = _noteBL.EditNote1(editNote, __userID);

            if (result != null)
            {
                return Ok(new { Success = true, Message = "Updated Successfully", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Something Went Wrong" });
            }
        }
        [HttpDelete("DeleteNote")]
        [Authorize]
        public IActionResult DeleteNote(NoteModel noteModel,  int _userID) {
            
            string userID=User.FindFirstValue(ClaimTypes.NameIdentifier);
            int __userID = Convert.ToInt32(userID);
            var result= _noteBL.DeleteNote(noteModel, __userID);
            if (result != null)
            {
                return Ok(new { Success = true, Message="Deleted Successfully",Data= result});
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Something Went Wrong" });
            }
        }
        [HttpGet("ViewNotes")]
        [Authorize]
        public IActionResult ViewNote(NoteModel noteModel, int _userID) {

            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int __userID = Convert.ToInt32(userID);
            var result=_noteBL.ViewNote(noteModel, __userID);

            if (result != null)
            {
                return Ok(new { Success = true, Message="Sucess",Data= result});
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Something went wrong" });
            }
        }





        /* [HttpPut]
         public IActionResult UpdateNote(NoteModel noteModel)
         {
             var result = _noteBL.UpdateNote(noteModel);
             if (result != null)
             {
                 return Ok(new { Success = true, Message="Added Successfully",Data= result});
             }
             else
             {
                 return BadRequest(new { Success = false, Message = "Somethiong went wrong" });
             }
         }*/

    }

}