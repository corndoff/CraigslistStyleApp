﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CraiglistAPI.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserState { get; set; }
    }
}