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
    public class BrandsController : ApiController
    {
        private EntityRepository<Brand> _brandsRepository = null;
        public BrandsController(
            EntityRepository<Brand> brandsRepository,
             BrandsRepository specificBrand = null
            )
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

        /*[HttpGet]
        [Route("api/brands/show")]
        public HttpResponseMessage GetBrandByName([FromUri] string brandNameInput)
        {

            var findBrandResult = ((BrandsRepository)_brandsRepository).FindBrandName(brandNameInput);

            if (findBrandResult.Contains(brandNameInput)) return Request.CreateResponse(HttpStatusCode.NotFound, $"Marque Trouver, Entrer {brandNameInput} et Sortie {findBrandResult.Contains(brandNameInput)} ");
            
            return Request.CreateResponse(HttpStatusCode.OK, $"Marque Introuver : {findBrandResult.Contains(brandNameInput)} !");
        }*/

        
    }
}
