// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserContext.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Context
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooNotes.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    /// UserContext Class
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext"/> class
        /// </summary>
        /// <param name="options">options as parameter</param>
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets Database set property for users table
        /// </summary>
        public DbSet<RegisterModel> Users { get; set; }

        /// <summary>
        /// Gets or sets Database set property for notes table
        /// </summary>
        public DbSet<NotesModel> Notes { get; set; }

        /// <summary>
        /// Gets or sets Database set property for collaborators table
        /// </summary>
        public DbSet<CollaboratorModel> Collaborators { get; set; }

        /// <summary>
        /// Gets or sets Database set property for label table
        /// </summary>
        public DbSet<LabelModel> Label { get; set; }
    }
}
