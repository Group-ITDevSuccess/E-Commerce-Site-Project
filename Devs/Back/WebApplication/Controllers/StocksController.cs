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
    public class StocksController : ApiController
    {
        private EntityRepository<Stocks> _stocksRepository = null;
        private EntityRepository<Products> _productsRepository = null;

        public StocksController(
            EntityRepository<Stocks> stocksRepository,
            EntityRepository<Products> productsRepository
            )
        {
            _stocksRepository = stocksRepository;
            _productsRepository = productsRepository;
        }

        [HttpGet]
        [Route("api/stocks")]
        public async Task<HttpResponseMessage> GetAllStock()
        {
            var allStocks = await _stocksRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allStocks);
        }

        [HttpPost]
        [Route("api/stocks/assign")]
        public async Task<HttpResponseMessage> AssignStock([FromUri] Guid idProduct, [FromBody] StocksReq stockInput)
        {
            var productSpecific = await _productsRepository.GetById(idProduct);
            if (productSpecific == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Produit selectionner n'existe pas !");
            var stock = new Stocks
            {
                Quantite = stockInput.Quantite,
                Remarque = stockInput.Remarque
            };

            productSpecific.Stock = new List<Stocks> { stock };


            stock.Product = new List<Products> { productSpecific };

            _stocksRepository.SaveOrUpdate(stock);
            _productsRepository.SaveOrUpdate(productSpecific);


            return Request.CreateResponse(HttpStatusCode.OK,
                $"Produit {productSpecific.ProductName} est assigner de stock de Quantité {stockInput.Quantite} et avec Remarque {stockInput.Remarque}");
        }
    }
}
