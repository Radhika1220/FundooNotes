// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Repository.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooNotes.Models;
    using global::Models;

    /// <summary>
    /// interface-for user repository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// definition for register method
        /// </summary>
        /// <param name="userData"> passing model</param>
        /// <returns>returning boolean value</returns>
        bool Register(RegisterModel userData);

        /// <summary>
        /// definition for login method
        /// </summary>
        /// <param name="email">Email as string type</param>
        /// <param name="password">password as string type</param>
        /// <returns>boolean type</returns>
        bool Login(string email, string password);

     /// <summary>
     /// definition for forgot password
     /// </summary>
     /// <param name="email">email as string type</param>
     /// <returns>boolean type </returns>
        bool ForgetPassword(string email);
        bool ResetPassword(ResetPasswordModel resetPassword);
    }
}
