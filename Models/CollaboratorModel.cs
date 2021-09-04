using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class CollaboratorModel
    {
        [Key]
        public int CId { get; set; }

        [Required]
        public string CEmailId { get; set; }

        [Display(Name = "NotesModel")]
        public virtual int NoteId { get; set; }

        [ForeignKey("NoteId")]
        public virtual NotesModel NotesModel { get; set; }

    }
}
