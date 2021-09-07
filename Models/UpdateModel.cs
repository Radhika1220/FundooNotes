// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Update model class
    /// </summary>
    public class UpdateModel
    {
        /// <summary>
        /// Gets or sets the note id
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
    }
}
