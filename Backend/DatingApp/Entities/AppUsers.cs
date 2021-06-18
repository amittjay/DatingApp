﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Entities
{
    public class AppUsers
    {
        public int Id{ get; set; }

        public string  UserName { get; set; }

        public byte[]  PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
