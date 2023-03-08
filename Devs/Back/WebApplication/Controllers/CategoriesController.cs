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
    public class CategoriesController : ApiController
    {
        private EntityRepository<Categories> _categoriesRepository = null;
        private EntityRepository<Products> _productsRepository = null;

        public CategoriesController(
            EntityRepository<Categories> categoriesRepository,
            EntityRepository<Products> productsRepository
            )
        {
            _categoriesRepository = categoriesRepository;
            _productsRepository = productsRepository;
        }

        [HttpGet]
        [Route("api/categories")]
        public async Task<HttpResponseMessage> GetAllCategories()
        {
            var allCategories = await _categoriesRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, allCategories);
        }
    }
}
