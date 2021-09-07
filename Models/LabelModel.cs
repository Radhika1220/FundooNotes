// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using FundooNotes.Models;

    /// <summary>
    /// Label model class
    /// </summary>
    public class LabelModel
    {
        /// <summary>
        /// Gets or sets the label id(primary key) 
        /// </summary>
        [Key]
        public int LabelId { get; set; }

        /// <summary>
        /// Gets or sets the label name (required)
        /// </summary>
        [Required]
        public string LabelName { get; set; }

        /// <summary>
        /// Gets or sets the user id as integer
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user id(foreign key) in register model
        /// </summary>
        [ForeignKey("UserId")]
        public virtual RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Gets or sets the note  id as integer
        /// </summary>
        public int? NoteId { get; set; }

        /// <summary>
        /// Gets or sets the note id(foreign key) in notes model
        /// </summary>
        [ForeignKey("NoteId")]
        public virtual NotesModel NotesModel { get; set; }
    }
}
