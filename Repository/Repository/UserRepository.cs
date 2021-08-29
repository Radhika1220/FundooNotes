using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public bool Register(RegisterModel userData)
        {
            try
            {
                if (userData != null)
                {
                    userData.password = EncryptPassWord(userData.password);
                    this.userContext.Users.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EncryptPassWord(string password)
        {
            var passwordInBytes = Encoding.UTF8.GetBytes(password);
            string encodePassword = Convert.ToBase64String(passwordInBytes);
            return encodePassword;
        }
        public bool Login(string email,string password)
        {
            try
            {
                //string message;
                string encodedPassword = EncryptPassWord(password);
                var login = this.userContext.Users.Where(x => x.email == email && x.password == encodedPassword).FirstOrDefault();
                if(login==null)
                {
                    //message = "Login Success";
                    return false;
                }
                else
                {
                    //message = "Login unsuccessful Email or password is wrong";
                    return true;
                }
                //return message;
            }
          catch(ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);

            }
        }
 
    }
}
