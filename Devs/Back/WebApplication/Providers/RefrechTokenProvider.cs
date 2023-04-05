using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using WebApplication.Business;
using WebApplication.Entity;

namespace WebApplication.Providers
{
    public class RefrechTokenProvider : IAuthenticationTokenProvider
    {
        private EntityRepository<Users> _usersRepository;
        public RefrechTokenProvider(EntityRepository<Users> usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            DateTime now = DateTime.UtcNow;
            context.Ticket.Properties.IssuedUtc = now;
            context.Ticket.Properties.ExpiresUtc = now.AddMinutes(Int32.Parse(ConfigurationManager.AppSettings["REFRESH_TOKEN_EXP_MINUTE"]));
            context.SetToken(context.SerializeTicket());
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            if (!context.OwinContext.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            }

            context.DeserializeTicket(context.Token);
        }

        public string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}