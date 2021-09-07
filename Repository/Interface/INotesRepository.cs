// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Models;

    /// <summary>
    /// Interface for notes repository
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Definition for AddNotes Method
        /// </summary>
        /// <param name="notesData">passing a note model</param>
        /// <returns>Returns a string message</returns>
        string AddNotes(NotesModel notesData);

        /// <summary>
        ///  Definition for Get notes method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotes(int userId);

        /// <summary>
        ///  Definition for Trash notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string TrashNotes(int notesId);

        /// <summary>
        ///  Definition for Archive notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string ArchiveNotes(int notesId);

        /// <summary>
        ///  Definition for UnArchive notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
        bool UnArchiveNotes(int notesId);

        /// <summary>
        ///  Definition for Restore notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
        bool RestoreNotes(int notesId);

        /// <summary>
        ///  Definition for  Pin notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string PinNotes(int notesId);

        /// <summary>
        ///  Definition for UnPin Notes method
        /// </summary>
        /// <param name="notesId">passing a note id as integer</param>
        /// <returns>Returns true or false</returns>
        bool UnPinNotes(int notesId);

        /// <summary>
        ///  Definition for update notes method
        /// </summary>
        /// <param name="updateData">passing a update model</param>
        /// <returns>Returns a list of data</returns>
        NotesModel UpdateNotes(UpdateModel updateData);

        /// <summary>
        ///  Definition for change color method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="color">passing a color name as string</param>
        /// <returns>Returns a list of data</returns>
        bool ChangeColor(int noteId, string color);

        /// <summary>
        ///  Definition for change remainder method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="remainder">passing a remainder as string</param>
        /// <returns>Returns a string message</returns>
        string ChangeRemainder(int noteId, string remainder);

        /// <summary>
        ///  Definition for delete notes method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string DeleteNotes(int noteId);

        /// <summary>
        ///  Definition for  delete remainder method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string DeleteRemainder(int noteId);

        /// <summary>
        ///  Definition for empty trash method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a string message</returns>
        string EmptyTrash(int userId);

        /// <summary>
        ///  Definition for get notes from remainder method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotesFromRemainder(int userId);

        /// <summary>
        ///  Definition for  get notes from archive method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotesFromArchive(int userId);

        /// <summary>
        ///  Definition for  get notes from trash method
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotesFromTrash(int userId);

        /// <summary>
        ///  Definition for upload image method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="image">passing a image as IForm file</param>
        /// <returns>Returns a string message</returns>
        string UploadImage(int noteId, IFormFile image);

        /// <summary>
        ///  Definition for remove image method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <returns>Returns a string message</returns>
        string RemoveImage(int noteId);
    }
}
