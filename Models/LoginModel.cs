﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class LoginModel
    {
        [Required]
        public string emailId { get; set; }

        [Required]
        public string password { get; set; }
    }
}
