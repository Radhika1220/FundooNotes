// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Managers.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooNotes.Managers.Interface;
    using FundooNotes.Models;
    using FundooNotes.Repository.Interface;
    using global::Models;

    /// <summary>
    /// Class user manager
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// declaring repository
        /// </summary>
        private readonly IUserRepository repoistory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class
        /// </summary>
        /// <param name="repoistory">repository as parameter</param>
        public UserManager(IUserRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        /// <summary>
        /// register method for manager class
        /// </summary>
        /// <param name="userData">passing register model data</param>
        /// <returns>true or false(boolean value)</returns>
        public string Register(RegisterModel userData)
        {
            try
            {
                return this.repoistory.Register(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// login method 
        /// </summary>
        /// <param name="email">email as string</param>
        /// <param name="password">password as string</param>
        /// <returns>boolean value</returns>
        public string Login(string email, string password)
        {
            try
            {
                return this.repoistory.Login(email, password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// forgot password method
        /// </summary>
        /// <param name="email">email as string</param>
        /// <returns>return true for repository</returns>
        public string ForgetPassword(string email)
        {
            try
            {
                // Send userdata to Repository and return result true or false
                return this.repoistory.ForgetPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Reset password method for manager class to pass data in repository
        /// </summary>
        /// <param name="resetPasswordModel">model as parameter</param>
        /// <returns>returns true </returns>
        public bool ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                // Send userdata to Repository and return result true or false
                return this.repoistory.ResetPassword(resetPasswordModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Generate token method
        /// </summary>
        /// <param name="email">passing a email id (string)</param>
        /// <returns>returns a string token</returns>
        public string GenerateToken(string email)
        {
            try
            {
                // Send userdata to Repository and return result true or false
                return this.repoistory.GenerateToken(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
