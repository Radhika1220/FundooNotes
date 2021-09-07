// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using global::Manager.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// Class collaborator manager
    /// </summary>
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// Declaring collaborator repository
        /// </summary>
        private readonly ICollaboratorRepository collaboratorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorManager"/> class
        /// </summary>
        /// <param name="collaboratorRepository">Passing a collaborator repository</param>
        public CollaboratorManager(ICollaboratorRepository collaboratorRepository)
        { 
            this.collaboratorRepository = collaboratorRepository;
        }

        /// <summary>
        /// Add collaborator for manager class
        /// </summary>
        /// <param name="collaboratorModel">Passing a collaborator model</param>
        /// <returns>returns a string message</returns>
        public string AddCollaborator(CollaboratorModel collaboratorModel)
        {
            try
            {
                return this.collaboratorRepository.AddCollaborator(collaboratorModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// delete collaborator 
        /// </summary>
        /// <param name="collaboratorId">passing a collaborator id</param>
        /// <returns>returns a string message</returns>
        public string DeleteCollaborator(int collaboratorId)
        {
            try
            {
                return this.collaboratorRepository.DeleteCollaborator(collaboratorId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get collaborator method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>returns a list of data</returns>
        public List<CollaboratorModel> GetCollaborator(int noteId)
        {
            try
            {
                return this.collaboratorRepository.GetCollaborator(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
