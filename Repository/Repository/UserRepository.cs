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
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Experimental.System.Messaging;
    using FundooNotes.Models;
    using FundooNotes.Repository.Interface;
    using global::Models;
    using global::Repository.Context;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Extensions.Configuration;
    using StackExchange.Redis;

    /// <summary>
    /// Class UserRepository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Declaring UserContext 
        /// </summary>
        private readonly UserContext userContext;

        private  IConfiguration configuration { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="userContext">Passing UserContext(DB model)</param>
        public UserRepository(UserContext userContext,IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// new Registration for user
        /// </summary>
        /// <param name="userData">RegisterModel Data</param>
        /// <returns>returns true</returns>
        public string Register(RegisterModel userData)
        {
            
            try
            {
                var check = this.userContext.Users.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (check == null)
                {
                    if (userData != null)
                    {
                        userData.Password = this.EncryptPassWord(userData.Password);
                        this.userContext.Users.Add(userData);
                        this.userContext.SaveChanges();
                        return "Registration Successful";
                    }

                    return "Registration UnSuccessful";
                }
                return "EmailId already Exists!!!Please login it";
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
        public string Login(string email, string password)
        {
            try
            {
                 // string message;
                string encodedPassword = this.EncryptPassWord(password);
                var login = this.userContext.Users.Where(x => x.Email == email && x.Password == encodedPassword).FirstOrDefault();

                ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                IDatabase database = connectionMultiplexer.GetDatabase();
                database.StringSet(key: "FirstName", login.FirstName);
                database.StringSet(key: "LastName", login.LastName);
                database.StringSet(key: "UserID", login.UserId.ToString());
               
                if (login == null)
                {
                    return "login unsuccessful";
                }
                else
                {
                    return "login successful";
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
                this.SendMSMQ();
                return this.SendMail(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SendMSMQ()
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
            var formatter = new BinaryMessageFormatter();
            message.Formatter = formatter;
            msgqueue.Label = "url Link";
            message.Body = "Reset link for password";
            msgqueue.Send(message);
         
        }
        private bool SendMail(string email)
        {
            string emailMessage = this.ReceiveMSMQ(email);
            if(SendMailToUser(email, emailMessage))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private string ReceiveMSMQ(string Email)
        {
            //for reading msmq
            var receivequeue = new MessageQueue(@".\Private$\MyQueue");
            var receivemsg = receivequeue.Receive();
            receivemsg.Formatter = new BinaryMessageFormatter();
            string emailMessage = receivemsg.Body.ToString();
            return emailMessage;
        }
            /// <summary>
            /// reset password method for repository class
            /// </summary>
            /// <param name="resetPassword">model as parameter</param>
            /// <returns>returns true if password is reset</returns>
            public bool ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                if (resetPassword != null)
                {
                    var data = this.userContext.Users.Where(x => x.Email == resetPassword.EmailId).FirstOrDefault();
                    if (data != null)
                    {
                        data.Password = this.EncryptPassWord(resetPassword.NewPassword);
                        this.userContext.SaveChanges();
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GenerateToken(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
        /// <summary>
        /// SMTP Configuration
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <param name="message">Message or url</param>
        /// <returns>returns true</returns>
        private bool SendMailToUser(string email, string message)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            mailMessage.From = new MailAddress("radhika.shankar1220@gmail.com");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Link to reset your password for Fundoo";
            mailMessage.Body = message;
            smtp.EnableSsl = true;
            mailMessage.IsBodyHtml = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("radhika.shankar1220@gmail.com", "kriyanthi");
            smtp.Send(mailMessage);
            return true;
        }
        }
    }