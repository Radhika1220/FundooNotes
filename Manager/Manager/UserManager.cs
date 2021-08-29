using FundooNotes.Managers.Interface;
using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Managers.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repoistory;

        public UserManager(IUserRepository repoistory)
        {
            this.repoistory = repoistory;
        }
        public bool Register(RegisterModel userData)
        {
            try
            {
                return this.repoistory.Register(userData);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
