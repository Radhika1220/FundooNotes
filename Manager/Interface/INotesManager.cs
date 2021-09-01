using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface INotesManager
    {
        string AddNotes(NotesModel notesModel);
        List<NotesModel> GetNotes(int userId);
        bool TrashNotes(int notesId);
        public bool ArchiveNotes(int notesId);
    }
}
