// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;

    /// <summary>
    /// Interface for label manager
    /// </summary>
    public interface ILabelManager
    {
        /// <summary>
        /// Definition for create label
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>Returns a string message</returns>
        string CreateLabel(LabelModel labelModel);

        /// <summary>
        /// Definition for add label
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a string message</returns>
        string AddLabel(LabelModel labelModel);

        /// <summary>
        /// Definition for remove label in notes
        /// </summary>
        /// <param name="labelId">passing a label id as integer</param>
        /// <returns>returns a string message</returns>
        string RemoveLabelInNotes(int labelId);

        /// <summary>
        /// Definition for delete label 
        /// </summary>
        /// <param name="labelName">passing a label name as string</param>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>returns a string message</returns>
        string DeleteLabel(string labelName, int userId);

        /// <summary>
        /// Definition for Get all labels
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<LabelModel> GetAllLabels(int userId);

        /// <summary>
        /// Definition for get label by notes
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>returns a list of data</returns>
        List<LabelModel> GetLabelByNotes(int noteId, int userId);

        /// <summary>
        /// Definition for edit label
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a string message</returns>
        string EditLabel(LabelModel labelModel);

        /// <summary>
        /// Definition for GetNotesByLabel method
        /// </summary>
        /// <param name="labelName">passing a label name as string</param>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotesByLabel(LabelModel labelModel);
    }
}
