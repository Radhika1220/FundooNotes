// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Manager.Interface;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;

    /// <summary>
    /// label controller class
    /// </summary>
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// Declaring a label manager
        /// </summary>
        private readonly ILabelManager labelManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController"/> class
        /// </summary>
        /// <param name="labelManager">passing a label manager</param>
        public LabelController(ILabelManager labelManager)
        {
            this.labelManager = labelManager;
        }

        /// <summary>
        /// Create label method 
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a IAction result</returns>
        [HttpPost]
        [Route("api/CreateLabel")]
        public IActionResult CreateLabel([FromBody] LabelModel labelModel)
        {
            try
            {
                string message = this.labelManager.CreateLabel(labelModel);
                if (message.Equals("Created Label Successfully"))
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

        /// <summary>
        /// Add label method 
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a IAction result</returns>
        [HttpPost]
        [Route("api/AddLabel")]
        public IActionResult AddLabel([FromBody] LabelModel labelModel)
        {
            try
            {
                string message = this.labelManager.AddLabel(labelModel);
                if (message.Equals("Label added successfully"))
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

        /// <summary>
        /// Remove label in notes method
        /// </summary>
        /// <param name="labelId">passing  a label id as integer</param>
        /// <returns>returns a IAction result</returns>
        [HttpDelete]
        [Route("api/RemoveLabelInNotes")]
        public IActionResult RemoveLabelInNotes(int labelId)
        {
            try
            {
                string message = this.labelManager.RemoveLabelInNotes(labelId);
                if (message.Equals("Label removed successfully in notes"))
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

        /// <summary>
        /// Delete label API
        /// </summary>
        /// <param name="labelName">passing a label name as string</param>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a IAction result</returns>
        [HttpDelete]
        [Route("api/DeleteLabel")]
        public IActionResult DeleteLabel(string labelName, int userId)
        {
            try
            {
                string message = this.labelManager.DeleteLabel(labelName, userId);
                if (message.Equals("Deleted Label Successfully"))
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

        /// <summary>
        /// Get All labels(home UI)
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>returns a IAction Result</returns>
        [HttpGet]
        [Route("api/GetAllLabels")]
        public IActionResult GetAllLabels(int userId)
        {
            try
            {
                var resMessage = this.labelManager.GetAllLabels(userId);
                if (resMessage != null)
                {
                    return this.Ok(new { Status = true, Message = "Label returned successfully", Data = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "label does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

       /// <summary>
       /// Get label by notes API
       /// </summary>
       /// <param name="noteId">passing a note id</param>
       /// <param name="userId">passing a user id</param>
       /// <returns>Returns a IAction Result</returns>
        [HttpGet]
        [Route("api/GetLabelByNotes")]
        public IActionResult GetLabelByNotes(int noteId, int userId)
        {
            try
            {
                var resMessage = this.labelManager.GetLabelByNotes(noteId, userId);
                if (resMessage != null)
                {
                    return this.Ok(new { Status = true, Message = "Label returned successfully", Data = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "label does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Edit label API
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a IAction result</returns>
        [HttpPost]
        [Route("api/EditLabel")]
        public IActionResult EditLabel([FromBody] LabelModel labelModel)
        {
            try
            {
                string message = this.labelManager.EditLabel(labelModel);
                if (message.Equals("Updated successfully"))
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
    }
}
