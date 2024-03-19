using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using ModelLayer;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace FundooNoteContext.Controllers
{
    [Route("api/Notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteBL _noteBL;
        private readonly IDistributedCache _distributedCache1;
        private readonly IRabitMQProducer _rabbitMQProducer;
       

        public NoteController(INoteBL noteBL, IDistributedCache distributedCache1,IRabitMQProducer rabitMQProducer)
        {
            this._noteBL = noteBL;
            this._distributedCache1 = distributedCache1;
            this._rabbitMQProducer = rabitMQProducer;
             
        }

        [HttpPost("AddNote")]
        [Authorize]
        public IActionResult AddNote(NoteModel noteModel)
        {

            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int _userID = Convert.ToInt32(userID);

            var result = _noteBL.AddNote(noteModel, _userID);

            _rabbitMQProducer.SendProductMessage(result);

            //var _distributedCache1.SetString(Convert.ToString(note.NoteId), JsonSerializer.Serialize(noteModel));
            //var _distributedCache1.SetString(Convert.ToString(result));
            //var result = _distributedCache1.SetString(Convert.ToString);
            //var _distributedCache1.ToString

            if (result != null)
            {
                _distributedCache1.SetString(Convert.ToString(result.NoteId), JsonSerializer.Serialize(noteModel));
                
                return Ok(new { Success = true, Message = "added sucessfully", Data = result });
            }
            else
            {

                return BadRequest(new { Success = false, Message = "something wet wrong" });
            }
        }

        [HttpPut("UpdateNote")]
        [Authorize]

        public IActionResult EditNote1(int _noteID, EditNote editNote)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int __userID = Convert.ToInt32(userID);
            var result = _noteBL.EditNote1(editNote, __userID);
           
            /*var catchnote = _distributedCache1.GetString(Convert.ToString(result.NoteId));     //EDIT Redis
            if(!string.IsNullOrEmpty(catchnote))                                               // Redis
            {
                var CatchNote1 = JsonSerializer.Deserialize<NoteEntity>(catchnote);             //Redis
                CatchNote1.Title = editNote.title;                                              //Redis
                _distributedCache1.SetString(Convert.ToString(result.NoteId), JsonSerializer.Serialize(CatchNote1)); //Redis
                
            }
            else                                                                                    //Redis
            {
                return null;                                                                        //Redis
            }
*/
            if (result != null)
            {
                return Ok(new { Success = true, Message = "Updated Successfully", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Something Went Wrong" });
            }
        }
        /*public IActionResult EditNote1(int _noteID, EditNote editNote)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int __userID = Convert.ToInt32(userID);

            var result = _noteBL.EditNote1(editNote, __userID);


            if (!string.IsNullOrEmpty(cachedNote))
            {
                var cachedNoteEntity = JsonSerializer.Deserialize<NoteEntity>(cachedNote);
                cachedNoteEntity.Title = editNote.title; // Assuming Title is the property to be updated

                // Update the cached note in Redis
                _distributedCache1.SetString(Convert.ToString(result.NoteId), JsonSerializer.Serialize(cachedNoteEntity));
            }
            else
            {
                // Optionally, you might want to log this case
                Console.WriteLine($"Note {_noteID} not found in Redis cache.");
            }
            if (result != null)
            {
                return Ok(new { Success = true, Message = "Updated Successfully", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Something Went Wrong" });
            }
        }*/
        [HttpDelete("DeleteNote")]
        [Authorize]
        public IActionResult DeleteNote(int _noteID, int _userID)
        {

            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int __userID = Convert.ToInt32(userID);
            var result = _noteBL.DeleteNote(_noteID, __userID);
            var catchnote = _distributedCache1.GetString(Convert.ToString(result.NoteId));
            if(!string.IsNullOrEmpty(catchnote))
            {
                _distributedCache1.Remove(Convert.ToString(result.NoteId));
            }
            else
            {
                return null;
            }

            if (result != null)
            {
                return Ok(new { Success = true, Message = "Deleted Successfully", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Something Went Wrong" });
            }
        }
        [HttpGet("ViewNotes")]
        [Authorize]
        public IActionResult ViewNote(int _noteID)
        {

            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int __userID = Convert.ToInt32(userID);
            var result = _noteBL.ViewNote(_noteID, __userID);

            var catchnote = _distributedCache1.GetString(Convert.ToString(result.NoteId));
            if(!string.IsNullOrEmpty(catchnote))
            {
                var cachedNotes = JsonSerializer.Deserialize<NoteEntity>(catchnote);
            }
            else
            {
                return null;
            }


            if (result != null)
            {
                return Ok(new { Success = true, Message = "Sucess", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Something went wrong" });
            }
        }
        [HttpPut("Arch_UnArc")]
        [Authorize]
        public IActionResult Archive_UnArchive(int _noteID)
        {
            string UserID = User.FindFirstValue("UserID");
            int _userID = Convert.ToInt32(UserID);

            bool Issucess = _noteBL.Archive_UnArchive(_userID, _noteID);
            if (Issucess)
            {
                return Ok(new { Success = true, Message = "Sucess" ,Data=Issucess});
            }
            else
            {
                return BadRequest(new { Success = false, Message = "something went wrong" });
            }

        }

    }

}
