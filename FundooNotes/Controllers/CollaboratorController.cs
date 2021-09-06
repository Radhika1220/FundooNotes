// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="Bridgelabz">
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
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Collaborator class
    /// </summary>
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// Instance for collaborator manager
        /// </summary>
        private readonly ICollaboratorManager collaboratorManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorController"/> class
        /// </summary>
        /// <param name="collaboratorManager">Collaborator Manager</param>
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }

        /// <summary>
        /// Add Collaborator API
        /// </summary>
        /// <param name="collaboratorModel">Collaborator Model</param>
        /// <returns>Returns a action result</returns>
        [HttpPost]
        [Route("api/AddCollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel collaboratorModel)
        {
            try
            {
                string message = this.collaboratorManager.AddCollaborator(collaboratorModel);
                if (message.Equals("Collaborator Added Successfully"))
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
        /// Delete Collaborator API
        /// </summary>
        /// <param name="collaboratorId">Collaborator id</param>
        /// <returns>IAction result</returns>
        [HttpDelete]
        [Route("api/DeleteCollaborator")]
        public IActionResult DeleteCollaborator(int collaboratorId)
        {
            try
            {
                string message = this.collaboratorManager.DeleteCollaborator(collaboratorId);
                if (message.Equals("Collaborator Deleted Successfully"))
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
        /// Get Collaborator API
        /// </summary>
        /// <param name="noteId">passing a note id</param>
        /// <returns>returns a IAction result</returns>
        [HttpGet]
        [Route("api/GetCollaborator")]

        public IActionResult GetCollaborator(int noteId)
        {
            try
            {
                var resMessage = this.collaboratorManager.GetCollaborator(noteId);
                if (resMessage != null)
                {
                    return this.Ok(new { Status = true, Message = "Collaborator Returned Successfully", Data = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No collaborator exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
