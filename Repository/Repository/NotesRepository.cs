using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;
        private readonly IConfiguration configuration;

        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }
        public string AddNotes(NotesModel notesData)
        {
            try
            {
                //if notes data is not null update the data in database
                if ((notesData.Title != null || notesData.Description != null || notesData.Remainder != null || notesData.Image != null))
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
                var emailId = this.userContext.Users.Where(a => a.UserId == UserId).Select(x => x.Email).SingleOrDefault();
                var checkNotes = this.userContext.Notes.Where(x => x.UserId == UserId && x.Trash == false && x.Archieve == false).ToList();
                var collaboratorNotes = (from notes in this.userContext.Notes
                                         join collaborator in this.userContext.Collaborators
                                         on notes.NoteId equals collaborator.NoteId
                                         where collaborator.CEmailId.Equals(emailId)
                                         select notes).ToList();
                if (checkNotes.Count > 0 || collaboratorNotes.Count > 0)
                {
                    checkNotes.AddRange(collaboratorNotes);
                }
              return checkNotes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string TrashNotes(int notesId)
        {
            string mes;
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId).SingleOrDefault();
                if (checkNotesId != null)
                {
                    if (checkNotesId.Pin == true)
                    {
                        checkNotesId.Pin = false;
                        mes = "Notes Unpinned and moved to trash";
                    }
                    else
                    {
                        mes = "Notes Moved to trash Successfully";
                    }
                    checkNotesId.Trash = true;
                    checkNotesId.Remainder = null;
                    this.userContext.Notes.Update(checkNotesId);
                    this.userContext.SaveChanges();

                    return mes;
                }
                    return "NoteId does not exist";
                
            }
            catch (Exception ex)
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

        public string ArchiveNotes(int notesId)
        {
            string message;
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId && x.Trash == false).SingleOrDefault();
                if (checkNotesId != null)
                {
                    if (checkNotesId.Pin == true)
                    {
                        checkNotesId.Pin = false;
                        message = "Notes unpinned and moved to Archived";
                    }
                    else
                    {
                        message = "Notes Moved to Archived Successfully";
                    }
                    checkNotesId.Archieve = true;
                    this.userContext.Notes.Update(checkNotesId);
                    this.userContext.SaveChanges();
                    return message;
                }
                return "Note Id does not exist";
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
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId && x.Trash == false).SingleOrDefault();
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


        public string PinNotes(int notesId)
        {
            string message;
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId && x.Trash == false).SingleOrDefault();
                if (checkNotesId != null)
                {
                    if(checkNotesId.Archieve==true)
                    {
                        checkNotesId.Archieve = false;
                        message = "Notes Unarchived and pinned";
                    }
                    else
                    {
                        message = "Pinned successfully";
                    }
                    checkNotesId.Pin = true;
                    this.userContext.Notes.Update(checkNotesId);
                    this.userContext.SaveChanges();
                    return message;
                }
                return "NoteId does not exist OR Trash is in false state";
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
                if (checkId != null)
                {
                    checkId.Title = updateData.Title;
                    checkId.Description = updateData.Description;
                    this.userContext.Notes.Update(checkId);
                    this.userContext.SaveChanges();
                    return checkId;
                }
                return checkId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeColor(int noteId, string color)
        {
            try
            {
                var checkNoteId = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (checkNoteId != null)
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


        public string ChangeRemainder(int noteId, string remainder)
        {
            try
            {
                var checkId = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
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
                var checkId = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == true).FirstOrDefault();
                if (checkId != null)
                {
                    this.userContext.Notes.Remove(checkId);
                    this.userContext.SaveChanges();
                    return "Deleted Notes Successfully";
                }
                return "Note Id  Does not Exist!!!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteRemainder(int noteId)
        {
            try
            {
                var checkId = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (checkId != null)
                {
                    checkId.Remainder = null;
                    this.userContext.Notes.Update(checkId);
                    this.userContext.SaveChanges();
                    return "Deleted Remainder Successfully";
                }
                return "NoteId does not exist OR Trash is in True state";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EmptyTrash(int userId)
        {
            try
            {
                var checkUserId = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == true).ToList();
                if (checkUserId.Count != 0)
                {
                    this.userContext.Notes.RemoveRange(checkUserId);
                    this.userContext.SaveChanges();
                    return "Emptied Trash Successfully";
                }
                return "Not Emptied";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public List<NotesModel> GetNotesFromRemainder(int UserId)
        {
            try
            {
                var checkUserId = this.userContext.Notes.Where(x => x.UserId == UserId && x.Trash == false && x.Remainder != null).ToList();
                if (checkUserId.Count > 0)
                {
                    return checkUserId;
                }
                return default;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<NotesModel> GetNotesFromArchive(int UserId)
        {
            try
            {
                var checkUserId = this.userContext.Notes.Where(x => x.UserId == UserId && x.Trash == false && x.Archieve==true).ToList();
                if (checkUserId.Count != 0)
                {
                    return checkUserId;
                }
                return default;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NotesModel> GetNotesFromTrash(int UserId)
        {
            try
            {
                var checkUserId = this.userContext.Notes.Where(x => x.UserId == UserId && x.Trash == true).ToList();
                if (checkUserId.Count != 0)
                {
                    return checkUserId;
                }
                return default;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UploadImage(int noteId,IFormFile image)
        {
            try
            {
                Account account = new Account(this.configuration.GetValue<string>("CloudinaryAccount:CloudName"), this.configuration.GetValue<string>("CloudinaryAccount:ApiKey"), this.configuration.GetValue<string>("CloudinaryAccount:ApiSecret"));
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream())
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                string res = uploadResult.Url.AbsoluteUri.ToString();

                var checkNoteId = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).SingleOrDefault();
                if (checkNoteId != null)
                {
                    checkNoteId.Image = res;
                    this.userContext.Notes.Update(checkNoteId);
                    this.userContext.SaveChanges();
                    return "Image Uploaded Succesfully";
                }
                return "Not Uploaded";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  

        public string RemoveImage(int noteId)
        {
            try
            {
                var checkNoteId = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if(checkNoteId!=null)
                {
                    checkNoteId.Image = null;
                    this.userContext.Notes.Update(checkNoteId);
                    this.userContext.SaveChanges();
                    return "Image Removed Successfully";
                }
                return "Image can't be removed";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}