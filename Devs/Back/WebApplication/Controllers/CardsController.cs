﻿using System;
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
    public class CardsController : ApiController
    {
        private EntityRepository<Cards> _cardsRepository = null;
        private EntityRepository<Agence> _agenceRepository = null;
        private EntityRepository<CardTypes> _cardTypesRepository = null;
        private EntityRepository<Users> _userRepository = null;

        public CardsController(
            EntityRepository<Cards> cardsRepository,
            EntityRepository<Agence> agenceRepository,
            EntityRepository<CardTypes> cardTypesRepository,
            EntityRepository<Users> userRepository
            )
        {
            _cardsRepository = cardsRepository;
            _agenceRepository = agenceRepository;
            _cardTypesRepository = cardTypesRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("api/cards")]
        public async Task<HttpResponseMessage> GetAllCards()
        {
            var allCards = await _cardsRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allCards);
        }

        [HttpPost]
        [Route("api/cards/agence")]
        public async Task<HttpResponseMessage> AssignCardsAgence([FromUri] Guid idAgence, [FromBody] CardsReq cardInput)
        {
            var specificalAgence = await _agenceRepository.GetById(idAgence);
            if (specificalAgence == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Agence Introuvable, impossible d'assigner de la carte");

            var cards = new Cards
            {
                Number = cardInput.Number,
                PassWord = cardInput.PassWord,
                Agence = specificalAgence
            };

            specificalAgence.Cards.Add(cards);
            _agenceRepository.SaveOrUpdate(specificalAgence);

            return Request.CreateResponse(HttpStatusCode.OK, $"Carte assigner à {specificalAgence.Name}");
        }

        [HttpPost]
        [Route("api/cards/types")]
        public async Task<HttpResponseMessage> AssignTypeCards([FromUri] Guid idCard, [FromBody] CardTypesReq typeInput)
        {
            var specificalCards = await _cardsRepository.GetById(idCard);

            if (specificalCards == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Carte Introuvable, impossible d'assigner de type à la carte");
            var specificalCardTypes = ((CardTypesRepository)_cardTypesRepository).FindCardTypesByName(typeInput.CardTypes);
            if (specificalCardTypes == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Type Carte Introuvable, impossible d'assigner de type à la carte");
            specificalCards.CardType = specificalCardTypes;


             _cardsRepository.SaveOrUpdate(specificalCards);
            
            return Request.CreateResponse(HttpStatusCode.OK, $"Type assigner à la Carte {specificalCards.Number}");
        }


        [HttpDelete]
        [Route("api/cards/delete")]
        public async Task<HttpResponseMessage> DeleteCard([FromUri] Guid idCard)
        {
            var specificalCard = await _cardsRepository.GetById(idCard);
            if (specificalCard == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Carte Introuvable, impossible de supprimer la carte");

            await _cardsRepository.Delete(specificalCard);
            return Request.CreateResponse(HttpStatusCode.OK, $"Carte de Numéro {specificalCard.Number} est supprimer !");
        }

        [HttpGet]
        [Route("api/cards/user")]
        public async Task<HttpResponseMessage> AssignCardClient([FromUri] Guid idCards, [FromUri] Guid idUser)
        {
            var userSpecific = await _userRepository.GetById(idUser);
            var cardSpecific = await _cardsRepository.GetById(idCards);

            if (userSpecific == null || cardSpecific == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"On a user = {userSpecific.FirstName} et card = {cardSpecific.Number}");

            userSpecific.Card = cardSpecific;
            
            var test = userSpecific;
            Console.WriteLine(test);

            _userRepository.SaveOrUpdate(userSpecific);
            return Request.CreateErrorResponse(HttpStatusCode.OK, "Cartes attribuer a au user !");
        }

    }
}
