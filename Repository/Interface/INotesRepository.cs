﻿using Models;
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

       bool ArchiveNotes(int notesId);

       bool UnArchiveNotes(int notesId);

        bool RestoreNotes(int notesId);

        bool PinNotes(int notesId);

        bool UnPinNotes(int notesId);

        NotesModel UpdateNotes(UpdateModel updateData);
        bool ChangeColor(int noteId, string color);
        string ChangeRemainder(int noteId, string remainder);
        string DeleteNotes(int noteId);
        string DeleteRemainder(int noteId);

        string EmptyTrash(int userId);

        List<NotesModel> GetNotesFromRemainder(int UserId);


        List<NotesModel> GetNotesFromArchive(int UserId);
    }
}
