﻿using FundooNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Repository.Interface
{
    public interface IUserRepository
    {
        bool Register(RegisterModel userData);
        bool Login(string email, string password);
        bool ForgetPassword(string Email);
    }
}
