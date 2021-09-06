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
    }
}
