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
    public class ClientsController : ApiController
    {
        private EntityRepository<Clients> _clientRepository = null;
        private EntityRepository<Cards> _cardsRepository = null;

        public ClientsController(
            EntityRepository<Clients> clientRepository,
            EntityRepository<Cards> cardsRepository
            )
        {
            _clientRepository = clientRepository;
            _cardsRepository = cardsRepository;
        }

        [HttpGet]
        [Route("api/clients")]
        public async Task<HttpResponseMessage> GetAllClients()
        {
            //EntityRepository<Clients> value = new EntityRepository<Clients>();
            
            var listOfAllClients = await _clientRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, listOfAllClients);
        }

        [HttpGet]
        [Route("api/clients")]
        public async Task<HttpResponseMessage> GetClientById([FromUri] Guid IdInput)
        {

            var findClientId = await _clientRepository.GetById(IdInput);

            if (findClientId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "L'Id du client saisi n'existe pas !");

            return Request.CreateResponse(HttpStatusCode.OK, findClientId);

        }

        [HttpPost]
        [Route("api/clients/add")]
        public HttpResponseMessage AddClient([FromBody] ClientsReq clientInput)
        {
            Clients client = new Clients();

            client.FirstNameClient = clientInput.FirstNameClient;
            client.LastNameClient = clientInput.LastNameClient;
            client.BirthDayClient = clientInput.BirthDayClient;
            client.GenreClient = clientInput.GenreClient;

            client.AddressClient = new AddressClients
            {
                City = clientInput.AddressClient.City,
                Country = clientInput.AddressClient.Country,
                Quarter = clientInput.AddressClient.Quarter,
                Street = clientInput.AddressClient.Street,
                Batch = clientInput.AddressClient.Batch,
                Postal_Code = clientInput.AddressClient.Postal_Code,
            };

            client.Account = new Accounts
            {
                Pseudo = clientInput.AccountClient.Pseudo,
                Email = clientInput.AccountClient.Email,
                PassWord = clientInput.AccountClient.PassWord,
            };

            try
            {
                _clientRepository.SaveOrUpdate(client);
                return Request.CreateResponse(HttpStatusCode.Created, "Client enregistré !");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Erreur lors de l'enregistrement du client : {e.Message}");
            }
        }

        [HttpPatch]
        [Route("api/clients/update")]
        public async Task<HttpResponseMessage> UpdateClient([FromUri] Guid idInput, [FromBody] ClientsReq clientInput)
        {

            var findClientId = await _clientRepository.GetById(idInput);
            if (findClientId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Client introuvable, mise ajour impossible !");

            findClientId.FirstNameClient = clientInput.FirstNameClient;
            findClientId.LastNameClient = clientInput.LastNameClient;
            findClientId.BirthDayClient = clientInput.BirthDayClient;
            findClientId.GenreClient = clientInput.GenreClient;

            _clientRepository.SaveOrUpdateAsynk(findClientId);
            return Request.CreateResponse(HttpStatusCode.OK, "Client Mise a Jour !");
        }

        [HttpDelete]
        [Route("api/clients/delete")]
        public async Task<HttpResponseMessage> DeleteClient ([FromUri] Guid idInput)
        {

            var findClientId = await _clientRepository.GetById(idInput);
            if (findClientId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Client introuvable, mise ajour impossible !");

            await _clientRepository.DeleteById(idInput);
            return Request.CreateResponse(HttpStatusCode.OK, "Client Effacer !");

        }
    }
}
