using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Manager
{
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
    }
}
