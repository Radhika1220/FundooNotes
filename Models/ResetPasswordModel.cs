// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetPasswordModel.cs" company="Bridgelabz">
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
    /// Class for reset password model
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets the email id as string
        /// </summary>
        [Required]

        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the new password as string
        /// </summary>
        [Required]

        public string NewPassword { get; set; }
    }
}
