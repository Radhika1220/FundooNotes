﻿using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Authorize]
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
                string message = this.notesManager.AddNotes(notesModel);
                if (message.Equals("Added Notes Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
                }
            }
            catch (Exception ex)
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
                if (resMessage != null)
                {
                    return this.Ok(new { Status = true, Message = "Notes returned successfully", Data = resMessage });
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
                string resultMessage = this.notesManager.TrashNotes(noteId);
                if (resultMessage.Equals("Notes Unpinned and moved to trash") || resultMessage.Equals("Notes Moved to trash Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = resultMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = resultMessage });
                }
            }
            catch (Exception ex)
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
                string result = this.notesManager.ArchiveNotes(noteId);
                if (result.Equals("Notes unpinned and moved to Archived") || result.Equals("Notes Moved to Archived Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
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
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "NoteId does not exist OR Trash is in false state" });
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
                if (res != null)
                {
                    return this.Ok(new { Status = true, Message = "Upated notes successfully", Data = updateModel });
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
        public IActionResult ChangeColor(int noteId, string color)
        {
            try
            {
                var result = this.notesManager.ChangeColor(noteId, color);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Color Changed successfully" });
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

        [HttpPut]
        [Route("api/ChangeReminder")]
        public IActionResult ChangeRemainder(int noteId, string remainder)
        {
            try
            {
                string result = this.notesManager.ChangeRemainder(noteId, remainder);
                if (result.Equals("Remainder Changed Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("api/DeleteNotes")]

        public IActionResult DeleteNotes(int noteId)
        {
            try
            {
                string result = this.notesManager.DeleteNotes(noteId);
                if (result.Equals("Deleted Notes Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/DeleteRemainder")]
        public IActionResult DeleteRemainder(int noteId)
        {
            try
            {
                string result = this.notesManager.DeleteRemainder(noteId);
                if (result.Equals("Deleted Remainder Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/EmptyTrash")]

        public IActionResult EmptyTrash(int userId)
        {
            try
            {
                string result = this.notesManager.EmptyTrash(userId);
                if (result.Equals("Emptied Trash Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetNotesFromRemainder")]
        public IActionResult GetNotesFromRemainder(int userId)
        {
            try
            {
                var resMessage = this.notesManager.GetNotesFromRemainder(userId);
                if (resMessage != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved Notes From Remainder Successfully", Data = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Remainder does not have notes" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetNotesFromArchive")]
        public IActionResult GetNotesFromArchive(int userId)
        {
            try
            {
                var resMessage = this.notesManager.GetNotesFromArchive(userId);
                if (resMessage != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved Notes From Archive Successfully", Data = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Archive does not have notes" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }



        [HttpGet]
        [Route("api/GetNotesFromTrash")]
        public IActionResult GetNotesFromTrash(int userId)
        {
            try
            {
                var resMessage = this.notesManager.GetNotesFromTrash(userId);
                if (resMessage != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved Notes From Trash Successfully", Data = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Trash does not have notes" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
