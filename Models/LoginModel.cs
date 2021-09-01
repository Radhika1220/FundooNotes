// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// Login model class
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets email id and it is required field
        /// </summary>
        [Required]
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets password and it is required field
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
