﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Entity;

namespace WebApplication.Interface
{
    public interface IAuthenticationStrategy
    {
        Users Authenticate(string clientId, string email, string password);
        void Logout(string email);
    }
}
