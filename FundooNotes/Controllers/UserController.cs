// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooNotes.Managers.Interface;
    using FundooNotes.Models;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;

    /// <summary>
    /// Controller class-controlling API
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// instance user manager 
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class
        /// </summary>
        /// <param name="manager">manager parameter</param>
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// controller-register  method
        /// </summary>
        /// <param name="userData">passing a register model data</param>
        /// <returns>return http status if registered successfully</returns>
        [HttpPost]
        [Route("api/register")]

        public IActionResult Register([FromBody] RegisterModel userData)
        {
            try
            {
                // sending data to manager
               string resMessage= this.manager.Register(userData);
                if (resMessage.Equals("Registration Successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = resMessage });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// login API for already existing user 
        /// </summary>
        /// <param name="loginData">login model data</param>
        /// <returns>returns http status if logged in successfully</returns>
        [HttpPost]
        [Route("api/Login")]

        public IActionResult Login([FromBody] LoginModel loginData)
        {
            try
            {
                string result = this.manager.Login(loginData.EmailId, loginData.Password);
                if (!(result.Equals("login unsuccessful")))
                {
                    string tokenString = this.manager.GenerateToken(loginData.EmailId);
                    return this.Ok(new { Status = true, Message = "Login Successful!!!",Data=tokenString, UserData= result.ToString()});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login UnSuccessful!!!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// forgot password data
        /// </summary>
        /// <param name="email">email as string type</param>
        /// <returns>returns http status </returns>
        [HttpPost]
        [Route("api/forgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                // Send user data to manager
                bool result = this.manager.ForgetPassword(email);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Please check your email" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Email not Sent" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// reset password  API
        /// </summary>
        /// <param name="resetPassword">passing a reset password data model</param>
        /// <returns>returns action result(http status)</returns>
        [HttpPut]
        [Route("api/resetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel resetPassword)
        {
            try
            {
                bool result = this.manager.ResetPassword(resetPassword);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reseted password successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "not reseted password correctly" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}