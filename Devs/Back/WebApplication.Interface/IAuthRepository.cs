using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Entity;

namespace WebApplication.Interface
{
    public interface IAuthRepository
    {
        Users FindByUserEmai(string email);
        void DisableGeneratedToken(string email);
        Users EnableGeneretedToken(string email);
        bool HasToken(string email);
    }
}
