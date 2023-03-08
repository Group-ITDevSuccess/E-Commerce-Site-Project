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
    public class BrandsController : ApiController
    {
        private EntityRepository<Brand> _brandsRepository = null;
        public BrandsController(EntityRepository<Brand> brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        [HttpGet]
        [Route("api/brands")]
        public async Task<HttpResponseMessage> GetAllBrands()
        {
            var allBrands = await _brandsRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, allBrands);
        }
    }
}
