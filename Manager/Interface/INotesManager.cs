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
        bool ArchiveNotes(int notesId);

       bool UnArchiveNotes(int notesId);

        bool RestoreNotes(int notesId);
        bool PinNotes(int notesId);
        bool UnPinNotes(int notesId);
    }
}
