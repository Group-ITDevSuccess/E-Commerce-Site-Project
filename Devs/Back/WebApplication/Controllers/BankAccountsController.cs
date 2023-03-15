using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication.Business;
using WebApplication.Entity;

namespace WebApplication.Controllers
{
    public class BankAccountsController : ApiController
    {
        private EntityRepository<BankAccount> _bankAccountsRepository = null;

        public BankAccountsController(EntityRepository<BankAccount> bankAccountsRepository)
        {
            _bankAccountsRepository = bankAccountsRepository;
        }

        [HttpGet]
        [Route("api/bank_account")]
        public async Task<HttpResponseMessage> GetAllBankAccount()
        {
            var allBankAccount = await ((BankAccountRepository)_bankAccountsRepository).GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, allBankAccount);
        }
    }
}
