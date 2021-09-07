// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Collaborator model data class
    /// </summary>
    public class CollaboratorModel
    {
        /// <summary>
        /// Gets or sets the collaborator id(primary key) 
        /// </summary>
        [Key]
        public int CId { get; set; }

        /// <summary>
        /// Gets or sets the collaborator email id as (required)
        /// </summary>
        [Required]
        public string CEmailId { get; set; }

        /// <summary>
        /// Gets or sets the note id as foreign key from notes model
        /// </summary>
        [Display(Name = "NotesModel")]
        public virtual int NoteId { get; set; }

        /// <summary>
        /// Gets or sets the note id 
        /// </summary>
        [ForeignKey("NoteId")]
        public virtual NotesModel NotesModel { get; set; }
    }
}
