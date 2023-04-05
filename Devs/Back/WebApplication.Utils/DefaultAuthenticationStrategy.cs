﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Entity;
using WebApplication.Interface;

namespace WebApplication.Utils
{
    public class DefaultAuthenticationStrategy : IAuthenticationStrategy
    {
        private IAuthRepository _authRepository = null;
        public DefaultAuthenticationStrategy(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        public Users Authenticate(string clientId, string email, string password)
        {
            return this._authRepository.EnableGeneretedToken(email);
        }

        public void Logout(string email)
        {
            this._authRepository.DisableGeneratedToken(email);
        }
    }
}
