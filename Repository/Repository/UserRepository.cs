// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;
    using Experimental.System.Messaging;
    using FundooNotes.Models;
    using FundooNotes.Repository.Interface;
    using global::Repository.Context;

    /// <summary>
    /// Class UserRepository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Declaring UserContext 
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="userContext">Passing UserContext(DB model)</param>
        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// new Registration for user
        /// </summary>
        /// <param name="userData">RegisterModel Data</param>
        /// <returns>returns true</returns>
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

        /// <summary>
        /// Encrypt The Password
        /// </summary>
        /// <param name="password">Passing Password To Encrypt</param>
        /// <returns>Encrypted Password</returns>
        public string EncryptPassWord(string password)
        {
            var passwordInBytes = Encoding.UTF8.GetBytes(password);
            string encodePassword = Convert.ToBase64String(passwordInBytes);
            return encodePassword;
        }

        /// <summary>
        /// For login 
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <param name="password">Password String type</param>
        /// <returns>Returns true if existing user present</returns>
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

        /// <summary>
        /// Forgot password API
        /// </summary>
        /// <param name="email">email type string </param>
        /// <returns>true if message sent to mail</returns>
        public bool ForgetPassword(string email)
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
                if (this.SendMail(email, linktosend))
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

        /// <summary>
        /// SMTP Configuration
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <param name="message">Message or url</param>
        /// <returns>returns true</returns>
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
