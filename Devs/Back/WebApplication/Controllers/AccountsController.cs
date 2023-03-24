using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication.Business;
using WebApplication.Entity;
using WebApplication.Entity.Services;

namespace WebApplication.Controllers
{
    public class AccountsController : ApiController
    {
        private EntityRepository<Accounts> _accountRepository = null;
        private EntityRepository<Clients> _clientsRepository = null;

        public AccountsController(
            EntityRepository<Accounts> accountRepository,
            EntityRepository<Clients> clientsRepository
            )
        {
            _accountRepository = accountRepository;
            _clientsRepository = clientsRepository;
        }

        [HttpGet]
        [Route("api/accounts")]
        public async Task<HttpResponseMessage> GetAllAcount()
        {
            var allAccount = await _accountRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, allAccount);
        }
    }
}
