// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelManager.cs" company="Bridgelabz">
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
    using Models;
    using Repository.Interface;

    /// <summary>
    /// Label manager class
    /// </summary>
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// Declaring a label repository 
        /// </summary>
        private readonly ILabelRepository labelRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelManager"/> class
        /// </summary>
        /// <param name="labelRepository">passing a label repository</param>
        public LabelManager(ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }

        /// <summary>
        /// Create label 
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a string message</returns>
        public string CreateLabel(LabelModel labelModel)
        {
            try
            {
                return this.labelRepository.CreateLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add label method
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a string message</returns>
        public string AddLabel(LabelModel labelModel)
        {
            try
            {
                return this.labelRepository.AddLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove label in notes
        /// </summary>
        /// <param name="labelId">passing a label id as integer</param>
        /// <returns>returns a string message</returns>
        public string RemoveLabelInNotes(int labelId)
        {
            try
            {
                return this.labelRepository.RemoveLabelInNotes(labelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Label
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a string message</returns>
        public string DeleteLabel(LabelModel labelModel)
        {
            try
            {
                return this.labelRepository.DeleteLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all labels
        /// </summary>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>returns a string message</returns>
        public List<LabelModel> GetAllLabels(int userId)
        {
            try
            {
                return this.labelRepository.GetAllLabels(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get label by notes 
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>returns a list of data</returns>
        public List<LabelModel> GetLabelByNotes(int noteId, int userId)
        {
            try
            {
                return this.labelRepository.GetLabelByNotes(noteId, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edit Label
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a string message</returns>
        public string EditLabel(LabelModel labelModel)
        {
            try
            {
                return this.labelRepository.EditLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Notes By Label
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotesByLabel(LabelModel labelModel)
        {
            try
            {
                return this.labelRepository.GetNotesByLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
