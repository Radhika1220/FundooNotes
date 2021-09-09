// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="Bridgelabz">
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
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// Label repository class
    /// </summary>
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// Declaring a user context
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRepository"/> class
        /// </summary>
        /// <param name="userContext">passing a user context</param>
        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Create model method
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a success or failed message</returns>
        public string CreateLabel(LabelModel labelModel)
        {
            try
            {
                var checkLabelName = this.userContext.Label.Where(a => a.LabelName.Equals(labelModel.LabelName) && a.UserId == labelModel.UserId).SingleOrDefault();
                if (checkLabelName == null)
                {
                    labelModel.NoteId = null;
                    this.userContext.Label.Add(labelModel);
                    this.userContext.SaveChanges();

                    return "Created Label Successfully";
                }

                return "Label already exists";
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
        /// <returns>returns a success or failed message</returns>
        public string AddLabel(LabelModel labelModel)
        {
            try
            {
                var noteId = labelModel.NoteId;
                this.CreateLabel(labelModel);
                labelModel.NoteId = noteId;
                var checkNoteId = this.userContext.Label.Where(a => a.LabelName.Equals(labelModel.LabelName) && a.NoteId == labelModel.NoteId).SingleOrDefault();
                if (checkNoteId == null)
                {
                    labelModel.LabelId = 0;
                    this.userContext.Label.Add(labelModel);
                    this.userContext.SaveChanges();
                    return "Label added successfully";
                }

                return "label not added successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove label in notes method
        /// </summary>
        /// <param name="labelId">passing a label id as integer</param>
        /// <returns>returns a success or failed message</returns>
        public string RemoveLabelInNotes(int labelId)
        {
            try
            {
                var checkLabelId = this.userContext.Label.Find(labelId);
                if (checkLabelId != null)
                {
                    this.userContext.Label.Remove(checkLabelId);
                    this.userContext.SaveChanges();
                    return "Label removed successfully in notes";
                }

                return "label not removed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete label method
        /// </summary>
        /// <param name="labelName">passing a label name as string</param>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>returns a success or failed message</returns>
        public string DeleteLabel(string labelName, int userId)
        {
            try
            {
                var exists = this.userContext.Label.Where(a => a.LabelName == labelName && a.UserId == userId).ToList();
                if (exists.Count != 0)
                {
                    this.userContext.Label.RemoveRange(exists);
                    this.userContext.SaveChanges();
                    return "Deleted Label Successfully";
                }

                return "no Label exist";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all labels method
        /// </summary>
        /// <param name="userId">passing a user id as integer </param>
        /// <returns>Returns a list of data</returns>
        public List<LabelModel> GetAllLabels(int userId)
        {
            try
            {
                var checkuserId = this.userContext.Label.Where(a => a.UserId == userId && a.NoteId == null).ToList();
                if (checkuserId.Count > 0)
                {
                    return checkuserId;
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get label by notes method
        /// </summary>
        /// <param name="noteId">passing a note id as integer</param>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>returns a list of data</returns>
       public List<LabelModel> GetLabelByNotes(int noteId, int userId)
        {
            try
            {
                var checkNoteId = this.userContext.Label.Where(a => a.NoteId == noteId && a.UserId == userId).ToList();
                if (checkNoteId.Count > 0)
                {
                    return checkNoteId;
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edit label method 
        /// </summary>
        /// <param name="labelModel">passing a label model</param>
        /// <returns>returns a success or failed message</returns>
        public string EditLabel(LabelModel labelModel)
        {
            string message = "Updated successfully";
            try
            {
                var oldLabeldata = this.userContext.Label.Where(x => x.LabelId == labelModel.LabelId).SingleOrDefault();
                var updateList = this.userContext.Label.Where(x => x.LabelName.Equals(oldLabeldata.LabelName) && x.UserId == labelModel.UserId).ToList();
                var checkLabelName = this.userContext.Label.Where(x => x.LabelName.Equals(labelModel.LabelName) && x.UserId == labelModel.UserId).FirstOrDefault();
                if (checkLabelName != null)
                {
                    var mergeLabel = this.userContext.Label.Find(labelModel.LabelId);
                    updateList.Remove(mergeLabel);
                    this.userContext.Label.Remove(mergeLabel);
                    this.userContext.SaveChanges();
                    message = "Merge the" + oldLabeldata.LabelName + " label with the" + checkLabelName.LabelName + " label? All notes labelled with" + oldLabeldata.LabelName + " will be labelled with" + checkLabelName.LabelName + " and the" + oldLabeldata.LabelName + " label will be deleted";
                }

                  foreach (var data in updateList)
                    {
                        data.LabelName = labelModel.LabelName;
                    }

                    this.userContext.Label.UpdateRange(updateList);
                    this.userContext.SaveChanges();
                    return message;
                }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Notes By Label
        /// </summary>
        /// <param name="labelName">passing a label name as string</param>
        /// <param name="userId">passing a user id as integer</param>
        /// <returns>Returns a list of data</returns>
        public List<NotesModel> GetNotesByLabel(LabelModel labelModel)
        {
            try
            {
                var noteIdList = this.userContext.Label.Where(a=>a.LabelName==labelModel.LabelName && a.UserId==labelModel.UserId && a.NoteId!=null).Select(x => x.NoteId).ToList();
                List<NotesModel> notesList = new List<NotesModel>();
                foreach (var data in noteIdList)
                {
                    var d = this.userContext.Notes.Where(x => x.NoteId == data).SingleOrDefault();
                    notesList.Add(d);
                }
                return notesList;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}