using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ILabelRepository
    {
        string CreateLabel(LabelModel labelModel);

    
        string AddLabel(LabelModel labelModel);
        string RemoveLabelInNotes(int labelId);

        string DeleteLabel(string labelName, int userId);

        List<LabelModel> GetAllLabels(int userId);


        List<LabelModel> GetLabelByNotes(int noteId,int userId);

        string EditLabel(LabelModel labelModel);
    }
}
