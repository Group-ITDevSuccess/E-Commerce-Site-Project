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
    public class AddressClientsController : ApiController
    {
        private EntityRepository<AddressClients> _addressClientsRepository = null;

        public AddressClientsController(EntityRepository<AddressClients> addressClientsRepository)
        {
            _addressClientsRepository = addressClientsRepository;
        }

        [HttpGet]
        [Route("api/address_client")]
        public async Task<HttpResponseMessage> GetAllAdressClients()
        {
            var addresses = await _addressClientsRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, addresses);
        }
    }
}
