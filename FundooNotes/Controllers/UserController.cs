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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using global::Models;
    using StackExchange.Redis;

    /// <summary>
    /// Controller class-controlling API
    /// </summary>
    ///[Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// declaring a variable for session name
        /// </summary>
         private const string SessionName = "_FullName";

        /// <summary>
        /// declaring a variable for session email id
        /// </summary>
         private const string SessionEmail = "_EmailId";

        /// <summary>
        /// instance user manager 
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// instance for logger
        /// </summary>
        private readonly ILogger<UserController> logger;

        /// <summary>
        ///  Initializes a new instance of the <see cref="UserController"/> class
        /// </summary>
        /// <param name="manager">passing a manager parameter</param>
        /// <param name="logger">passing a logger parameter</param>
        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
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
            this.logger.LogInformation("API For Registration For Accessing Notes");
            try
            {
                HttpContext.Session.SetString(SessionName, userData.FirstName + " " + userData.LastName);
                HttpContext.Session.SetString(SessionEmail, userData.Email);
                this.logger.LogInformation(userData.FirstName + " " + userData.LastName + " Is trying to register");
                ////sending data to manager
                string resMessage = this.manager.Register(userData);
                if (resMessage.Equals("Registration Successful"))
                {
                   string name = HttpContext.Session.GetString(SessionName);
                   string email = HttpContext.Session.GetString(SessionEmail);
                   this.logger.LogInformation(userData.FirstName + " Is Registered Successfully");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = resMessage, Data = "Session Name :" + name + " Email Id :" + email });
                }
                else
                {
                    this.logger.LogWarning("Registration Unsuccesfull");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = resMessage });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Exception Occured While Register " + ex.Message);
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
            this.logger.LogInformation("API For Login to access the notes");
            try
            {
                this.logger.LogInformation(loginData.EmailId + " Is Logging ");
                string result = this.manager.Login(loginData.EmailId, loginData.Password);
                if (result.Equals("login successful"))
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string firstName = database.StringGet("FirstName");
                    string lastName = database.StringGet("LastName");
                    int userId = Convert.ToInt32(database.StringGet("UserID"));

                    RegisterModel data = new RegisterModel
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        UserId = userId,
                        Email = loginData.EmailId
                    };
                    this.logger.LogInformation(loginData.EmailId + " Logged Successfully");
                    string tokenString = this.manager.GenerateToken(loginData.EmailId);
                    return this.Ok(new { Status = true, Message = "Login Successful!!!", Data = tokenString, UserData = data });
                }
                else
                {
                    this.logger.LogWarning("Login Unsuccessfull");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login UnSuccessful!!!" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Exception Occured While log in " + ex.Message);
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
            this.logger.LogInformation("API For Forgot Password ");
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
            this.logger.LogInformation("API For Reset Passoword");
            try
            {
                this.logger.LogInformation(resetPassword.EmailId + " Is trying to reset the password");
                bool result = this.manager.ResetPassword(resetPassword);
                if (result == true)
                {
                    this.logger.LogInformation(resetPassword.EmailId + " Reseted Password Successfully");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reseted password successfully" });
                }
                else
                {
                    this.logger.LogWarning("Not Reseted Passowrd Successfully");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "not reseted password correctly" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Exception Occured While in Reset the password " + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}