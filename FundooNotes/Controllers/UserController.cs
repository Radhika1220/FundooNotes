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
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

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
    }
}
