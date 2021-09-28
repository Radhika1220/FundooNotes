// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{ 
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Models;

    /// <summary>
    /// Interface for notes manager
    /// </summary>
    public interface INotesManager
    {
        /// <summary>
        /// Definition for Add notes method
        /// </summary>
        /// <param name="notesModel">passing a notes model</param>
        /// <returns>Returns a string message</returns>
        NotesModel AddNotes(NotesModel notesModel);

        /// <summary>
        /// Definition for Get notes 
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotes(int userId);

        /// <summary>
        /// Definition for trash notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string TrashNotes(int notesId);

        /// <summary>
        /// Definition for archive notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string ArchiveNotes(int notesId);

        /// <summary>
        /// Definition for UnArchive notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        bool UnArchiveNotes(int notesId);

        /// <summary>
        /// Definition for Restore notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
        bool RestoreNotes(int notesId);

        /// <summary>
        /// Definition for Pin notes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>>Returns a string message</returns>
        string PinNotes(int notesId);

        /// <summary>
        /// Definition for UnPinNotes
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
        bool UnPinNotes(int notesId);

        /// <summary>
        /// Definition for Update notes
        /// </summary>
        /// <param name="updateModel">passing a update model</param>
        /// <returns>Returns a note model </returns>
        NotesModel UpdateNotes(UpdateModel updateModel);

        /// <summary>
        /// Definition for Change color
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="color">passing a color name as string</param>
        /// <returns>Returns true or false</returns>
        bool ChangeColor(int noteId, string color);

        /// <summary>
        /// Definition for Change remainder
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="remainder">passing a remainder as string</param>
        /// <returns>Returns a string message</returns>
        string ChangeRemainder(int noteId, string remainder);

        /// <summary>
        /// Definition for delete notes
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string DeleteNotes(int noteId);

        /// <summary>
        /// Definition for delete remainder
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string DeleteRemainder(int noteId);

        /// <summary>
        /// Definition for empty trash
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string EmptyTrash(int noteId);

        /// <summary>
        /// Definition for get notes from remainder
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotesFromRemainder(int userId);

        /// <summary>
        /// Definition for get notes from trash
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotesFromTrash(int userId);

        /// <summary>
        /// Definition for get notes from archive
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotesFromArchive(int userId);

        /// <summary>
        /// Definition for upload image
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="image">passing a image in IForm file</param>
        /// <returns>Returns a string message</returns>
        string UploadImage(int noteId, IFormFile image);

        /// <summary>
        /// Definition for remove image
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string RemoveImage(int noteId);
    }
}
