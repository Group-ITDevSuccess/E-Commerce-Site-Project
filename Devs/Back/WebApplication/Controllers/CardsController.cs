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
    public class CardsController : ApiController
    {
        private EntityRepository<Cards> _cardsRepository = null;

        public CardsController(EntityRepository<Cards> cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        [HttpGet]
        [Route("api/cards")]
        public virtual async Task<HttpResponseMessage> GetAllCards()
        {
            var allCards = await _cardsRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allCards);
        }

    }
}
