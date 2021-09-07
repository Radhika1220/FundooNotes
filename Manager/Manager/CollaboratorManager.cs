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

    public class CollaboratorManager:ICollaboratorManager
    {
        
    
        private readonly ICollaboratorRepository collaboratorRepository;

        public CollaboratorManager(ICollaboratorRepository collaboratorRepository)
        { 
            this.collaboratorRepository = collaboratorRepository;
        }

        public string AddCollaborator(CollaboratorModel collaboratorModel)
        {
            try
            {
                return this.collaboratorRepository.AddCollaborator(collaboratorModel);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


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
