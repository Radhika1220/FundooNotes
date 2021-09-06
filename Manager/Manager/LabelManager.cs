using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Manager
{
    public class LabelManager:ILabelManager
    {
        private readonly ILabelRepository labelRepository;

        public LabelManager(ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }

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



        public string DeleteLabel(string labelName,int userId)
        {
            try
            {
                return this.labelRepository.DeleteLabel(labelName,userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
