// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using Experimental.System.Messaging;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

     /// <summary>
     /// Collaborator repository class
     /// </summary>
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// declaring  a User Context 
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class
        /// </summary>
        /// <param name="userContext">passing a user context </param>
        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// add collaborator method
        /// </summary>
        /// <param name="collaboratorModel">passing a collaborator model</param>
        /// <returns>returns a fail or success message</returns>
        public string AddCollaborator(CollaboratorModel collaboratorModel)
        {
            try
            {
                var checkOwner = this.userContext.Notes.Where(x => x.UserId == this.userContext.Users.Where(u => u.Email == collaboratorModel.CEmailId).Select(u => u.UserId).SingleOrDefault() && x.NoteId == collaboratorModel.NoteId).SingleOrDefault();
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

        /// <summary>
        /// Delete Collaborator method
        /// </summary>
        /// <param name="noteId">Passing a note id</param>
        /// <returns>Returns a success or fail message</returns>
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

        /// <summary>
        /// Get collaborator
        /// </summary>
        /// <param name="noteId">passing a note id</param>
        /// <returns>Returns a list of data</returns>
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