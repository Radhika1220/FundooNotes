// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;

    /// <summary>
    /// Interface for Collaborator Manager
    /// </summary>
    public interface ICollaboratorManager
    {
        /// <summary>
        /// Definition for Add collaborator method
        /// </summary>
        /// <param name="collaboratorModel">collaborator model</param>
        /// <returns>Returns a string message</returns>
        string AddCollaborator(CollaboratorModel collaboratorModel);

        /// <summary>
        /// definition for delete collaborator
        /// </summary>
        /// <param name="collaboratorId">passing collaborator id</param>
        /// <returns>returns a string message</returns>
        string DeleteCollaborator(int collaboratorId);

        /// <summary>
        /// Definition for get collaborator
        /// </summary>
        /// <param name="noteId">passing a note id</param>
        /// <returns>Returns a list of data</returns>
        List<CollaboratorModel> GetCollaborator(int noteId);
    }
}
