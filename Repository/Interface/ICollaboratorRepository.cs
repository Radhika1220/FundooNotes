using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ICollaboratorRepository
    {
        string AddCollaborator(CollaboratorModel collaboratorModel);

        string DeleteCollaborator(int collaboratorId);

        List<CollaboratorModel> GetCollaborator(int noteId);
    }
}
