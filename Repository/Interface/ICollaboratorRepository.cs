// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;

    /// <summary>
    /// interface-for collaborator repository
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// definition for add collaborator 
        /// </summary>
        /// <param name="collaboratorModel">passing a collaborator model</param>
        /// <returns>returns a string message</returns>
        string AddCollaborator(CollaboratorModel collaboratorModel);

        /// <summary>
        /// Definition for delete collaborator
        /// </summary>
        /// <param name="collaboratorId">passing  a collaborator id as integer</param>
        /// <returns>returns a string message</returns>
        string DeleteCollaborator(int collaboratorId);

        /// <summary>
        /// Definition for get collaborator
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>returns a list of data</returns>
        List<CollaboratorModel> GetCollaborator(int noteId);
    }
}
