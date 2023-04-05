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
    public class AddressController : ApiController
    {
        private EntityRepository<Address> _addressRepository = null;

        public AddressController(EntityRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        [Route("api/address_client")]
        public async Task<HttpResponseMessage> GetAllAdressClients()
        {
            var addresses = await _addressRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, addresses);
        }
    }
}
