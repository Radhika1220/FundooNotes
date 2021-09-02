using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository notesRepository;

        public NotesManager(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public string AddNotes(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.AddNotes(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<NotesModel> GetNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool TrashNotes(int notesId)
        {
            try
            {
                return this.notesRepository.TrashNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RestoreNotes(int notesId)
        {
            try
            {
                return this.notesRepository.RestoreNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ArchiveNotes(int notesId)
        {
            try
            {
                return this.notesRepository.ArchiveNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UnArchiveNotes(int notesId)
        {
            try
            {
                return this.notesRepository.UnArchiveNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool PinNotes(int notesId)
        {
            try
            {
                return this.notesRepository.PinNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UnPinNotes(int notesId)
        {
            try
            {
                return this.notesRepository.UnPinNotes(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public NotesModel UpdateNotes(UpdateModel updateModel)
        {
            try
            {
                return this.notesRepository.UpdateNotes(updateModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeColor(int noteId, string color)
        {
            try
            {
                return this.notesRepository.ChangeColor(noteId, color);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ChangeRemainder(int noteId, string remainder)
        {
            try
            {
                return this.notesRepository.ChangeRemainder(noteId, remainder);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteNotes(int noteId)
        {
            try
            {
                return this.notesRepository.DeleteNotes(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteRemainder(int noteId)
        {
            try
            {
                return this.notesRepository.DeleteRemainder(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EmptyTrash(int noteId)
        {
            try
            {
                return this.notesRepository.EmptyTrash(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
