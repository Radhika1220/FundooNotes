using Experimental.System.Messaging;
using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Repository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly UserContext userContext;

        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddCollaborator(CollaboratorModel collaboratorModel)
        {
            try
            {
                var checkOwner = this.userContext.Notes.Where(x => x.UserId == (this.userContext.Users.Where(u => u.Email == collaboratorModel.CEmailId).Select(u => u.UserId).SingleOrDefault()) && x.NoteId == collaboratorModel.NoteId).SingleOrDefault();

                if (checkOwner == null)
                {
                    var result = this.userContext.Collaborators.Where(x => x.NoteId == collaboratorModel.NoteId && x.CEmailId == collaboratorModel.CEmailId).SingleOrDefault();
                    if (result == null)
                    {
                        this.userContext.Collaborators.Add(collaboratorModel);
                        this.userContext.SaveChanges();
                        return "Collaborator Added Successfully";
                    }
                }
                return "Email Id Already exists";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public string DeleteCollaborator(int noteId)
        {
            try
            {
                var checkId = this.userContext.Collaborators.Where(a => a.NoteId == noteId).SingleOrDefault();
                if (checkId != null)
                {
                    this.userContext.Collaborators.Remove(checkId);
                    this.userContext.SaveChanges();
                    return "Collaborator Deleted Successfully";
                }
               return "Collaborator does not exist";  
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
                var checkCollaboratorId = this.userContext.Collaborators.Where(x => x.NoteId == noteId).ToList();
                if (checkCollaboratorId.Count > 0)
                {
                    return checkCollaboratorId;
                }
                return default;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}