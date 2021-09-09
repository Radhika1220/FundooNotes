// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;

    /// <summary>
    /// Interface for label repository 
    /// </summary>
    public interface ILabelRepository
    {
        /// <summary>
        /// Definition for Create label
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a string message</returns>
        string CreateLabel(LabelModel labelModel);
        
        /// <summary>
        /// Definition for Add label 
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a string message</returns>
        string AddLabel(LabelModel labelModel);

        /// <summary>
        /// Definition for Remove label in notes
        /// </summary>
        /// <param name="labelId">passing a label id as integer</param>
        /// <returns>returns a string message</returns>
        string RemoveLabelInNotes(int labelId);

        /// <summary>
        /// Definition for delete label
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>Returns a string message</returns>
        string DeleteLabel(LabelModel labelModel);

        /// <summary>
        /// Definition for Get all labels
        /// </summary>
        /// <param name="userId">passing a user id</param>
        /// <returns>returns a list of data</returns>
        List<LabelModel> GetAllLabels(int userId);

        /// <summary>
        /// Definition for Get label by notes
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
        /// Definition for Get Notes By Label
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>Returns a list of data</returns>
        List<NotesModel> GetNotesByLabel(LabelModel labelModel);
    }
}
