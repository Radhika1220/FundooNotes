// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ---------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Manager.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;

    /// <summary>
    /// Notes controller class
    /// </summary>
    [Authorize]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// Declaring a object for notes manager
        /// </summary>
        private readonly INotesManager notesManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class
        /// </summary>
        /// <param name="notesManager">passing a notes manager</param>
        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }

        /// <summary>
        /// Add notes API
        /// </summary>
        /// <param name="notesModel">passing a notes model </param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPost]
        [Route("api/AddNotes")]
        public IActionResult AddNotes([FromBody] NotesModel notesModel)
        {
            try
            {
                var message = this.notesManager.AddNotes(notesModel);
                if (message!=null)
                {
                    return this.Ok( new { Status = true, message.NoteId,Message = "Added Sucessfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Not added successfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get notes API
        /// </summary>
        /// <param name="userId">passing a user id</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Trash notes API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Restore notes API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Archive Notes API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// UnArchive Notes
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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
        
        /// <summary>
        /// Pin notes API 
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/PinNotes")]
        public IActionResult PinNotes(int noteId)
        {
            try
            {
                string result = this.notesManager.PinNotes(noteId);
                if (result.Equals("Notes Unarchived and pinned") || result.Equals("Pinned successfully"))
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

        /// <summary>
        /// UnPin Notes API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Update Notes API
        /// </summary>
        /// <param name="updateModel">passing a update model</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Change Color API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="color">passing a color name as string</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Change Remainder API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="remainder">passing a remainder name as string</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Delete Notes API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Delete Remainder API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        ///  Empty trash API
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Get notes from remainder API
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Get notes from Archive API
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Get notes from Trash API
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a IAction Result</returns>
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

        /// <summary>
        /// Upload Image API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="image">passing a image in IForm File</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPost]
        [Route("api/UploadImage")]
        public IActionResult UploadImage(int noteId, IFormFile image)
        {
            try
            {
                string resMessage = this.notesManager.UploadImage(noteId, image);
                if (resMessage.Equals("Image Uploaded Succesfully"))
                {
                    return this.Ok(new { Status = true, Message = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = resMessage });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Remove Image API
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a IAction Result</returns>
        [HttpPut]
        [Route("api/RemoveImage")]
        public IActionResult RemoveImage(int noteId)
        {
            try
            {
                string resMessage = this.notesManager.RemoveImage(noteId);
                if (resMessage.Equals("Image Removed Successfully"))
                {
                    return this.Ok(new { Status = true, Message = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = resMessage });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
