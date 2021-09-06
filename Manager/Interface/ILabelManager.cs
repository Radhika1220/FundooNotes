using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface ILabelManager
    {
        string CreateLabel(LabelModel labelModel);

        string AddLabel(LabelModel labelModel);

        string RemoveLabelInNotes(int labelId);

        string DeleteLabel(string labelName, int userId);


        List<LabelModel> GetLabel(int userId);
    }
}
