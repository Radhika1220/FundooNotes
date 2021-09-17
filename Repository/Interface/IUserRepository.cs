// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Repository.Interface
{
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
        string Register(RegisterModel userData);

        /// <summary>
        /// definition for login method
        /// </summary>
        /// <param name="email">Email as string type</param>
        /// <param name="password">password as string type</param>
        /// <returns>boolean type</returns>
        string Login(string email, string password);

        /// <summary>
        /// definition for forgot password
        /// </summary>
        /// <param name="token">token</param>
        /// <returns>string message</returns>
        string ForgetPassword(string email);

        /// <summary>
        /// definition for reset password in user repository class
        /// </summary>
        /// <param name="resetPassword">passing a model as parameter</param>
        /// <returns>returns true </returns>
        bool ResetPassword(ResetPasswordModel resetPassword);

        /// <summary>
        /// Definition for generate token 
        /// </summary>
        /// <param name="email">passing a string email id</param>
        /// <returns>returns a string token</returns>
        string GenerateToken(string email);
    }
}
