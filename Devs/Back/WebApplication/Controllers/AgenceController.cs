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

        [HttpGet]
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

        [HttpDelete]
        [Route("api/agences/delete")]
        public async Task<HttpResponseMessage> DeleteCard([FromUri] Guid idCard)
        {
            var specificalCard = await _cardsRepository.GetById(idCard);
            if (specificalCard == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Carte Introuvable, impossible de supprimer la carte");

            await _cardsRepository.DeleteById(idCard);
            return Request.CreateResponse(HttpStatusCode.OK, $"Carte de Numéro {specificalCard.Number} est supprimer !");
        }
    }
}
