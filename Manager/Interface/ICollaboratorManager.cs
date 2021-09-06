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
        /// 
        /// </summary>
        /// <param name="collaboratorModel"></param>
        /// <returns></returns>
        string AddCollaborator(CollaboratorModel collaboratorModel);

        string DeleteCollaborator(int collaboratorId);

        List<CollaboratorModel> GetCollaborator(int noteId);
    }
}
