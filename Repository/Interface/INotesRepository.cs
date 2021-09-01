using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface INotesRepository
    {
        string AddNotes(NotesModel notesData);
        List<NotesModel> GetNotes(int UserId);

        bool TrashNotes(int notesId);
    }
}
