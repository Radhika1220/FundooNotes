// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Managers.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooNotes.Models;
    using global::Models;

    /// <summary>
    /// interface for user manager class
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// definition for register method
        /// </summary>
        /// <param name="userData">passing a register model</param>
        /// <returns>returning as boolean value</returns>
        bool Register(RegisterModel userData);

        /// <summary>
        /// definition for login method
        /// </summary>
        /// <param name="email">email as string</param>
        /// <param name="password">[password as string</param>
        /// <returns>boolean value</returns>
        bool Login(string email, string password);

        /// <summary>
        /// definition for forgot password
        /// </summary>
        /// <param name="email">email as string type</param>
        /// <returns>boolean value</returns>
        bool ForgetPassword(string email);

        /// <summary>
        /// reset password definition
        /// </summary>
        /// <param name="resetPasswordModel">reset password model data</param>
        /// <returns>returns true</returns>
        bool ResetPassword(ResetPasswordModel resetPasswordModel);
    }
}
