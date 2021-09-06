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
    }
}
