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
                if (notesData != null &&(notesData.Title!=null || notesData.Description!=null || notesData.Remainder!=null || notesData.Image!=null))
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

        public bool TrashNotes(int notesId)
        {
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId).SingleOrDefault();
                if(checkNotesId != null)
                {
                    checkNotesId.Trash = true;
                    this.userContext.Notes.Update(checkNotesId);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RestoreNotes(int notesId)
        {
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId).SingleOrDefault();
                if (checkNotesId != null)
                {
                    checkNotesId.Trash = false;
                    this.userContext.Notes.Update(checkNotesId);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ArchiveNotes(int notesId)
        {
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId && x.Trash==false).SingleOrDefault();
                if (checkNotesId != null)
                {
                    checkNotesId.Archieve = true;
                    this.userContext.Notes.Update(checkNotesId);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UnArchiveNotes(int notesId)
        {
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId).SingleOrDefault();
                if (checkNotesId != null)
                {
                    checkNotesId.Archieve = false;
                    this.userContext.Notes.Update(checkNotesId);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool PinNotes(int notesId)
        {
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId && x.Trash == false).SingleOrDefault();
                if (checkNotesId != null)
                {
                    checkNotesId.Pin = true;
                    this.userContext.Notes.Update(checkNotesId);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UnPinNotes(int notesId)
        {
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId && x.Trash == false).SingleOrDefault();
                if (checkNotesId != null)
                {
                    checkNotesId.Pin = false;
                    this.userContext.Notes.Update(checkNotesId);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public NotesModel UpdateNotes(UpdateModel updateData)
        {
            try
            {
                var checkId = this.userContext.Notes.Where(x => x.NoteId == updateData.NoteId && x.Trash == false).SingleOrDefault();
                if(checkId!=null)
                {
                    checkId.Title = updateData.Title;
                    checkId.Description = updateData.Description;
                    this.userContext.Notes.Update(checkId);
                    this.userContext.SaveChanges();
                    return checkId;
                }
                return checkId;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeColor(int noteId,string color)
        {
            try
            {
                var checkNoteId = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if(checkNoteId!=null)
                {
                    checkNoteId.Color = color;
                    this.userContext.Notes.Update(checkNoteId);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string ChangeRemainder(int noteId,string remainder)
        {
            try
            {
                var checkId = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (checkId != null)
                {
                    checkId.Remainder = remainder;
                    this.userContext.Notes.Update(checkId);
                    this.userContext.SaveChanges();
                    return "Remainder Changed Successfully";
                }
                return "Note Id Does not Exist!!!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteNotes(int noteId)
        {
            try
            {
                var checkId = this.userContext.Notes.Where(x => x.NoteId == noteId  && x.Trash==true).FirstOrDefault();
                if(checkId!=null)
                {
                    this.userContext.Notes.Remove(checkId);
                    this.userContext.SaveChanges();
                    return "Deleted Notes Successfully";
                }
                return "Note Id  Does not Exist!!!";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}