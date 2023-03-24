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

        [HttpPost]
        [Route("api/accounts/assign")]
        public async Task<HttpResponseMessage> AssignAccount([FromUri] Guid idClient, [FromBody] AccountReq accountInput)
        {
            var findClient = await _clientsRepository.GetById(idClient);

            if (findClient == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Utilisateur Introuvable, impossible d'assigner de compte");

            var accounts = new Accounts
            {
                Pseudo = accountInput.Pseudo,
                Email = accountInput.Email,
                PassWord = accountInput.PassWord,
                Client = findClient
            };

            findClient.Account.Add(accounts);

            _clientsRepository.SaveOrUpdate(findClient);

            return Request.CreateResponse(HttpStatusCode.OK, $"Compte Assigner à {findClient.FirstNameClient}");
        }
    }
}
