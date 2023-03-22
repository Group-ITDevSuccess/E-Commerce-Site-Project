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
using WebApplication.Enum;

namespace WebApplication.Controllers
{
    public class CardTypesController : ApiController
    {
        private EntityRepository<CardTypes> _cardTypesRepository = null;
        public CardTypesController
        (
            EntityRepository<CardTypes> cardTypesRepository
        )
        {
            _cardTypesRepository = cardTypesRepository;
        }

        [HttpGet]
        [Route("api/card_types")]
        public async Task<HttpResponseMessage> GetAllCardTypes()
        {
            var allCardTypes = await _cardTypesRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allCardTypes);
        }


        [HttpPost]
        [Route("api/cards_types/name")]
        public HttpResponseMessage FindCardTypesByName([FromBody] CardTypesReq cardTypeInput)
            
        {
            try
            {  
                var specificalCardTypes = ((CardTypesRepository)_cardTypesRepository).FindCardTypesByName(cardTypeInput.CardTypes);
                
                
                if (specificalCardTypes == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Le Type Carte Introuvable");

                return Request.CreateErrorResponse(HttpStatusCode.OK, "Le Type Carte trouver est: " + specificalCardTypes.CardType);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
