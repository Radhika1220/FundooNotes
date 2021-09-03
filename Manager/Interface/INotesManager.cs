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
        string TrashNotes(int notesId);
        bool ArchiveNotes(int notesId);

       bool UnArchiveNotes(int notesId);

        bool RestoreNotes(int notesId);
        bool PinNotes(int notesId);
        bool UnPinNotes(int notesId);

        NotesModel UpdateNotes(UpdateModel updateModel);
        bool ChangeColor(int noteId, string color);
        string ChangeRemainder(int noteId, string remainder);

        string DeleteNotes(int noteId);

        string DeleteRemainder(int noteId);

        string EmptyTrash(int noteId);

        List<NotesModel> GetNotesFromRemainder(int userId);

        List<NotesModel> GetNotesFromTrash(int userId);

        List<NotesModel> GetNotesFromArchive(int userId);
    }
}
