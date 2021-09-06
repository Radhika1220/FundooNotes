using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class LabelRepository : ILabelRepository

    {
        private readonly UserContext userContext;

        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

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


        public string AddLabel(LabelModel labelModel)
        {
            try
            {
                var noteId = labelModel.NoteId;
                CreateLabel(labelModel);
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


        public string RemoveLabelInNotes(int labelId)
        {
            try
            {
                var checkLabelId = this.userContext.Label.Find(labelId);
                if(checkLabelId!=null)
                {
                    this.userContext.Label.Remove(checkLabelId);
                    this.userContext.SaveChanges();
                    return "Label removed successfully in notes";
                }
                return "label not removed";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteLabel(string labelName,int userId)
        {
            try
            {
                var exists = this.userContext.Label.Where(a => a.LabelName == labelName && a.UserId == userId).ToList();
                if (exists.Count != 0)
                {
                    this.userContext.Label.RemoveRange(exists);
                    this.userContext.SaveChanges();
                    return "Deleted Label Successfully" ;
                }
                return "no Label exist";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LabelModel> GetLabel (int userId)
        {
            try
            {
                var checkuserId = this.userContext.Label.Where(a=>a.UserId==userId).ToList();
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
    }
    }

