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
        public virtual async Task<HttpResponseMessage> GetAllCardTypes()
        {
            var allCardTypes = await _cardTypesRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allCardTypes);
        }
    }
}
