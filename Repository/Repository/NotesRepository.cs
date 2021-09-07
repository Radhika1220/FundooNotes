// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// Notes Repository class
    /// </summary>
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// Declaring object for user context
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Declaring object for configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class
        /// </summary>
        /// <param name="userContext">passing a user context</param>
        /// <param name="configuration">passing a configuration</param>
        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }
        
        /// <summary>
        /// Add notes method
        /// </summary>
        /// <param name="notesData">passing a note model</param>
        /// <returns>Returns success or failed message</returns>
        public string AddNotes(NotesModel notesData)
        {
            try
            {
                // if notes data is not null update the data in database
                if (notesData.Title != null || notesData.Description != null || notesData.Remainder != null || notesData.Image != null)
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

        /// <summary>
        /// Get notes method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotes(int userId)
        {
            try
            {
                var emailId = this.userContext.Users.Where(a => a.UserId == userId).Select(x => x.Email).SingleOrDefault();
                var checkNotes = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == false && x.Archieve == false).ToList();
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

        /// <summary>
        /// Trash notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns success or failed message</returns>
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

        /// <summary>
        /// Restore notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
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

        /// <summary>
        /// Archive notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns success or failed message</returns>
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

        /// <summary>
        /// UnArchive notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
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

        /// <summary>
        /// Pin notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns success or failed message</returns>
        public string PinNotes(int notesId)
        {
            string message;
            try
            {
                var checkNotesId = this.userContext.Notes.Where(x => x.NoteId == notesId && x.Trash == false).SingleOrDefault();
                if (checkNotesId != null)
                {
                    if (checkNotesId.Archieve == true)
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

        /// <summary>
        /// UnPin Notes Method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
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

        /// <summary>
        /// Update Notes Method
        /// </summary>
        /// <param name="updateData">passing a update model</param>
        /// <returns>Returns a list of data</returns>
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

        /// <summary>
        /// Change Color Method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="color">passing a color name as string</param>
        /// <returns>Returns a true or false</returns>
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

        /// <summary>
        /// Change Remainder Method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="remainder">passing a remainder as string</param>
        /// <returns>Returns success or failed message</returns>
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

        /// <summary>
        /// Delete Notes Method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns success or failed message</returns>
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

        /// <summary>
        /// Delete Remainder Method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns success or failed message</returns>
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

        /// <summary>
        /// Empty Trash Method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns success or failed message</returns>
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

        /// <summary>
        /// Get Notes From Remainder Method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotesFromRemainder(int userId)
        {
            try
            {
                var checkUserId = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == false && x.Remainder != null).ToList();
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

        /// <summary>
        /// Get Notes From Archive Method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotesFromArchive(int userId)
        {
            try
            {
                var checkUserId = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == false && x.Archieve == true).ToList();
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

        /// <summary>
        /// Get Notes From Trash Method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotesFromTrash(int userId)
        {
            try
            {
                var checkUserId = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == true).ToList();
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

        /// <summary>
        /// Upload Image Method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="image">passing a image as IForm file</param>
        /// <returns>Returns success or failed message</returns>
        public string UploadImage(int noteId, IFormFile image)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove Image Method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns success or failed message</returns>
        public string RemoveImage(int noteId)
        {
            try
            {
                var checkNoteId = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (checkNoteId != null)
                {
                    checkNoteId.Image = null;
                    this.userContext.Notes.Update(checkNoteId);
                    this.userContext.SaveChanges();
                    return "Image Removed Successfully";
                }

                return "Image can't be removed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}