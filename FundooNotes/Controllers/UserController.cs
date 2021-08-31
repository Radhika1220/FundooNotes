using FundooNotes.Managers.Interface;
using FundooNotes.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserManager manager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/register")]

        public IActionResult Register([FromBody] RegisterModel userData)
        {
            try
            {
                //sending data to manager
               bool result= this.manager.Register(userData);
               if(result==true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Registration Successful!!!" });
                }
               else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Registration UnSuccessful!!!" });
                }
            }
            catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Login")]

        public IActionResult Login([FromBody] LoginModel loginData)
        {
            try
            {
                bool result = this.manager.Login(loginData.EmailId, loginData.Password);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Login Successful!!!" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login UnSuccessful!!!" });
                }       
            }
            catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forgetPassword")]
        public IActionResult ForgetPassword(string Email)
        {
            try
            {
                //Send user data to manager
                bool result = this.manager.ForgetPassword(Email);
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
    }
}
