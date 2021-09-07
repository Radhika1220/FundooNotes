// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
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
    /// Notes model class
    /// </summary>
    public class NotesModel
    {
        /// <summary>
        /// Gets or sets the note id(primary key) 
        /// </summary>
        [Key]
        public int NoteId { get; set; }

        /// <summary>
        ///  Gets or sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }
          
        /// <summary>
        /// Gets or sets the Remainder
        /// </summary>
        public string Remainder { get; set; }

        /// <summary>
        /// Gets or sets the Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether status as true or false
        /// </summary>
        [DefaultValue(false)]
        public bool Pin { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether status as true or false
        /// </summary>
        [DefaultValue(false)]
        public bool Archieve { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether status as true or false
        /// </summary>
        [DefaultValue(false)]
        public bool Trash { get; set; }

        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        [Display(Name = "RegisterModel")]
        public virtual int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user id as foreign key
        /// </summary>
        [ForeignKey("UserId")]
        public virtual RegisterModel RegisterModel { get; set; }
    }
}
