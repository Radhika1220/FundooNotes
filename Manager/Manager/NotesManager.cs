// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="Bridgelabz">
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
    using Microsoft.AspNetCore.Http;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// notes manager class
    /// </summary>
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// object for notes repository
        /// </summary>
        private readonly INotesRepository notesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager"/> class
        /// </summary>
        /// <param name="notesRepository">passing a notes repository</param>
        public NotesManager(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        /// <summary>
        /// Add notes
        /// </summary>
        /// <param name="notesModel">passing a notes model</param>
        /// <returns>Returns a string message</returns>
        public string AddNotes(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.AddNotes(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get notes 
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trash notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        public string TrashNotes(int notesId)
        {
            try
            {
                return this.notesRepository.TrashNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restore notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
        public bool RestoreNotes(int notesId)
        {
            try
            {
                return this.notesRepository.RestoreNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Archive Notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        public string ArchiveNotes(int notesId)
        {
            try
            {
                return this.notesRepository.ArchiveNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UnArchive Notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a true or false</returns>
        public bool UnArchiveNotes(int notesId)
        {
            try
            {
                return this.notesRepository.UnArchiveNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Pin Notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        public string PinNotes(int notesId)
        {
            try
            {
                return this.notesRepository.PinNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UnPin Notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
        public bool UnPinNotes(int notesId)
        {
            try
            {
                return this.notesRepository.UnPinNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update Notes
        /// </summary>
        /// <param name="updateModel">passing a update model</param>
        /// <returns>Returns a list of data</returns>
        public NotesModel UpdateNotes(UpdateModel updateModel)
        {
            try
            {
                return this.notesRepository.UpdateNotes(updateModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Change Color
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="color">passing a color name as string</param>
        /// <returns>Returns true or false</returns>
        public bool ChangeColor(int noteId, string color)
        {
            try
            {
                return this.notesRepository.ChangeColor(noteId, color);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Change Remainder
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="remainder">passing a remainder as string</param>
        /// <returns>Returns a string message</returns>
        public string ChangeRemainder(int noteId, string remainder)
        {
            try
            {
                return this.notesRepository.ChangeRemainder(noteId, remainder);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Notes
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        public string DeleteNotes(int noteId)
        {
            try
            {
                return this.notesRepository.DeleteNotes(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Remainder
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        public string DeleteRemainder(int noteId)
        {
            try
            {
                return this.notesRepository.DeleteRemainder(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Empty Trash
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        public string EmptyTrash(int noteId)
        {
            try
            {
                return this.notesRepository.EmptyTrash(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Notes From Remainder
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotesFromRemainder(int userId)
        {
            try
            {
                return this.notesRepository.GetNotesFromRemainder(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Notes From Archive
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotesFromArchive(int userId)
        {
            try
            {
                return this.notesRepository.GetNotesFromArchive(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Notes From Trash
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotesFromTrash(int userId)
        {
            try
            {
                return this.notesRepository.GetNotesFromTrash(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Upload Image
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="image">passing a image in IForm File</param>
        /// <returns>Returns a string message</returns>
        public string UploadImage(int noteId, IFormFile image)
        {
            try
            {
                return this.notesRepository.UploadImage(noteId, image);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove Image
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        public string RemoveImage(int noteId)
        {
            try
            {
                return this.notesRepository.RemoveImage(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
