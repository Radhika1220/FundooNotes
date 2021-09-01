using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class NotesRepository:INotesRepository
    {
        private readonly UserContext userContext;

        public NotesRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public string AddNotes(NotesModel notesData)
        {
            try
            {
               //if notes data is not null update the data in database
                if (notesData != null)
                {
                    this.userContext.Notes.Add(notesData);
                    this.userContext.SaveChanges();
                    return "Added Notes Successfully";
                }
                return "Not added Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<NotesModel> GetNotes(int UserId)
        {
            try
            {
                var checkUserId = this.userContext.Notes.Where(x => x.UserId == UserId).ToList();
                if (checkUserId != null)
                {
                    return checkUserId;
                }
                return checkUserId;
             
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}