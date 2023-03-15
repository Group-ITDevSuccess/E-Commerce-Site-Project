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
    public class CardsController : ApiController
    {
        private EntityRepository<Cards> _cardsRepository = null;
        private EntityRepository<Agence> _agenceRepository = null;

        public CardsController(
            EntityRepository<Cards> cardsRepository,
            EntityRepository<Agence> agenceRepository
            )
        {
            _cardsRepository = cardsRepository;
            _agenceRepository = agenceRepository;
        }

        [HttpGet]
        [Route("api/cards")]
        public async Task<HttpResponseMessage> GetAllCards()
        {
            var allCards = await _cardsRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allCards);
        }

        [HttpPost]
        [Route("api/cards/assign")]
        public async Task<HttpResponseMessage> AssignCardsAgence([FromUri] Guid idAgence, [FromBody] CardsReq cardInput)
        {
            var specificalAgence = await _agenceRepository.GetById(idAgence);
            if (specificalAgence == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Agence Introuvable, impossible d'assigner de la carte");
            var cards = new Cards
            {
                PassWord = cardInput.PassWord,
                Agence = specificalAgence
            };

            specificalAgence.Cards.Add(cards);
            _agenceRepository.SaveOrUpdate(specificalAgence);

            return Request.CreateResponse(HttpStatusCode.OK, $"Carte assigner à {specificalAgence.Name}");
        }

        
    }
}
