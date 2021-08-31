
using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using Repository.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System;
using Experimental.System.Messaging;

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
                    userData.Password = this.EncryptPassWord(userData.Password);
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

   
        public bool Login(string email, string password)
        {
            try
            {
                // string message;
                string encodedPassword = this.EncryptPassWord(password);
                var login = this.userContext.Users.Where(x => x.Email == email && x.Password == encodedPassword).FirstOrDefault();
                if (login == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
              
            }

          catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);

            }

        }
 
        public bool ForgetPassword(string Email)
        {
            try
            {
                MessageQueue msgqueue;
                if (MessageQueue.Exists(@".\Private$\MyQueue"))
                {
                    msgqueue = new MessageQueue(@".\Private$\MyQueue");
                }
                else
                {
                    msgqueue = MessageQueue.Create(@".\Private$\MyQueue");
                }

                Message message = new Message();
                message.Formatter = new BinaryMessageFormatter();
                message.Body = "Reset link for passowrd";
                msgqueue.Label = "url Link";
                msgqueue.Send(message);

                ////for reading msmq
                var receivequeue = new MessageQueue(@".\Private$\MyQueue");
                var receivemsg = receivequeue.Receive();
                receivemsg.Formatter = new BinaryMessageFormatter();

                string linktosend = receivemsg.Body.ToString();
                if (this.SendMail(Email, linktosend))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        private bool SendMail(string email, string message)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            mailMessage.From = new MailAddress("radhika.shankar1220@gmail.com");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Link to reset your password for Fundoo";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("radhika.shankar1220@gmail.com", "kriyanthi");
            smtp.Send(mailMessage);
            return true;
        }
    }
}
