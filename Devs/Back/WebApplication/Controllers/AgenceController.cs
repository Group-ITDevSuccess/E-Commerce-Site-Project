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
    public class AgenceController : ApiController
    {
        private EntityRepository<Agence> _agenceRepository = null;
        private EntityRepository<Cards> _cardsRepository = null;
        public AgenceController(
            EntityRepository<Agence> agenceRepository,
            EntityRepository<Cards> cardsRepository
            )
        {
            _agenceRepository = agenceRepository;
            _cardsRepository = cardsRepository;
        }

        [HttpPost]
        [Route("api/agences")]
        public async Task<HttpResponseMessage> GetAllAgence()
        {
            var allAgences = await _agenceRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allAgences);
        }

        [HttpPost]
        [Route("api/agences/add")]
        public HttpResponseMessage AddAgence([FromBody] AgenceReq agenceInput)
        {
            Agence agence = new Agence();

            agence.Name = agenceInput.Name;
            agence.Denomination = agenceInput.Denomination;

            try
            {
                _agenceRepository.SaveOrUpdate(agence);
                return Request.CreateResponse(HttpStatusCode.Created, "Agence enregistré !");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Erreur lors de l'enregistrement du client : {e.Message}");
            }
        }

        [HttpPost]
        [Route("api/agences/cards")]
        public async Task<HttpResponseMessage> GetCardsByAgenceId([FromUri]Guid idAgence)
        {
            var agence = await _agenceRepository.GetById(idAgence);
            if (agence == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Agence avec ID {idAgence} introuvable.");
            }

            var cards = ((CardsRepository)_cardsRepository).GetByAgenceId(idAgence);
            return Request.CreateResponse(HttpStatusCode.OK, cards);
        }
/*
        [HttpPost]
        [Route("api/agences/update")]
        public async Task<HttpResponseMessage> UpdateAgence([FromUri] Guid idAgence, [FromBody] AgenceReq agenceInput)
        {

        }*/

        [HttpGet]
        [Route("api/agences/delete")]
        public async Task<HttpResponseMessage> DeleteAgence([FromUri] Guid idAgence)
        {

            var agenceToDelete = await _agenceRepository.GetById(idAgence);
            if (agenceToDelete == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Agence introuvable, impossible de supprimier l'agence");

            var cardsToDelete = ((CardsRepository)_cardsRepository).GetByAgenceId(idAgence);

            foreach (var card in cardsToDelete)
            {
                await _cardsRepository.Delete(card);
            }

            await _agenceRepository.DeleteById(idAgence);

            return Request.CreateResponse(HttpStatusCode.OK, $"Tout les cartes associer au Agence {agenceToDelete.Name} sont supprimier");
        }


    }
}
