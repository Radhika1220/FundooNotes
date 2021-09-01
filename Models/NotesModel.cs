using FundooNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class NotesModel
    {
        [Key]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description {get;set;}
        public string Remainder { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }

        [DefaultValue(false)]
        public bool Pin { get; set; }

        [DefaultValue(false)]
        public bool Archieve { get; set; }

        [DefaultValue(false)]
        public bool Trash { get; set; }

        [Display(Name = "RegisterModel")]
        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual RegisterModel RegisterModel { get; set; }
    }
}
