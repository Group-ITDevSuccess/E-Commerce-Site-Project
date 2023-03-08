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
    public class ProductsController : ApiController
    {
        private EntityRepository<Products> _productRepository = null;

        public ProductsController(EntityRepository<Products> productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [Route("api/products")]
        public virtual async Task<HttpResponseMessage> GetAllProducts()
        {
            var allProducts = await _productRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, allProducts);
        }

        [HttpPost]
        [Route("api/products/add")]
        public virtual HttpResponseMessage AddProduct([FromBody] ProductsReq productInput)
        {
            Products value = new Products();
            value.ProductName = productInput.ProductName;
            value.ProductPrice = productInput.ProductPrice;
            value.ProductDescription = productInput.ProductDescription;
            value.BrandProduct = new Brand
            {
                BrandName = productInput.ProductBrand.BrandName
            };

            try
            {
                _productRepository.SaveOrUpdate(value);
                return Request.CreateResponse(HttpStatusCode.OK, "Produit enregistrer !");
            }
            catch (Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, 
                    $"Erreur lors de l'enregistrement du Produit : {e.Message}");
            }
        }  
    }
}
