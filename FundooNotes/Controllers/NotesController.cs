using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class NotesController : ControllerBase
    {
        private readonly INotesManager notesManager;

        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }
        
        [HttpPost]
        [Route("api/AddNotes")]
        public IActionResult AddNotes([FromBody] NotesModel notesModel)
        {
            try
            {
                //addnotes api
                string message = this.notesManager.AddNotes(notesModel);
                if(message.Equals("Added Notes Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
                }
            }
            catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/GetNotes")]

        public IActionResult GetNotes(int userId)
        {
            try
            {
                var resMessage = this.notesManager.GetNotes(userId);
                if (resMessage!=null)
                {
                    return this.Ok(new { Status = true, Message ="Notes returned successfully",Data=resMessage});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "UserId does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/TrashNotes")]
        public IActionResult TrashNotes(int noteId)
        {
            try
            {
                bool result = this.notesManager.TrashNotes(noteId);
                if(result==true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Notes Moved to trash successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "NoteId does not exist" });
               }
            }
            catch(Exception ex)
            {
               return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/RestoreNotes")]
        public IActionResult RestoreNotes(int noteId)
        {
            try
            {
                bool result = this.notesManager.RestoreNotes(noteId);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Notes Restored successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "NoteId does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ArchiveNotes")]
        public IActionResult ArchiveNotes(int noteId)
        {
            try
            {
                bool result = this.notesManager.ArchiveNotes(noteId);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Notes Moved to Archive successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "NoteId does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UnArchiveNotes")]
        public IActionResult UnArchiveNotes(int noteId)
        {
            try
            {
                bool result = this.notesManager.UnArchiveNotes(noteId);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Notes UnArchived successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "NoteId does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/PinNotes")]
        public IActionResult PinNotes(int noteId)
        {
            try
            {
                bool result = this.notesManager.PinNotes(noteId);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Pinned successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "NoteId does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }


        [HttpPut]
        [Route("api/UnPinNotes")]
        public IActionResult UnPinNotes(int noteId)
        {
            try
            {
                bool result = this.notesManager.UnPinNotes(noteId);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "UnPinned successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "NoteId does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UpdateNotes")]
        public IActionResult UpdateNotes([FromBody] UpdateModel updateModel)
        {
            try 
            {
                var res = this.notesManager.UpdateNotes(updateModel);
                if(res!=null)
                {
                    return this.Ok(new { Status = true, Message = "Upated notes successfully",Data=updateModel });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "NoteId does not exist!! OR Notes does not Updated" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/ChangeColor")]
        public IActionResult ChangeColor(int noteId,string color)
        {
            try
            {
                var result = this.notesManager.ChangeColor(noteId, color);
                if(result==true)
                {
                    return this.Ok(new { Status = true, Message = "Color Changed successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "NoteId does not exist!!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        
        }
    }
}
