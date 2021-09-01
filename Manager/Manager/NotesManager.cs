using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Manager
{
    public class NotesManager:INotesManager
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
            catch(Exception ex)
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
    }
}
