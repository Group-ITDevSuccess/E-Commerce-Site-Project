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
        [HttpGet]
        [Route("api/clients")]
        public async Task<HttpResponseMessage> GetAllClients()
        {
            EntityRepository<Clients> value = new EntityRepository<Clients>();

            var listOfAllClients = await value.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, listOfAllClients);
        }

        [HttpGet]
        [Route("api/clients")]
        public async Task<HttpResponseMessage> GetClientById([FromUri] Guid IdInput)
        {
            EntityRepository<Clients> value = new EntityRepository<Clients>();

            var findClientId = await value.GetById(IdInput);

            if (findClientId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "L'Id du client saisi n'existe pas !");

            return Request.CreateResponse(HttpStatusCode.OK, findClientId);

        }

        [HttpPost]
        [Route("api/clients/add")]
        public HttpResponseMessage AddClient([FromBody] ClientsReq clientInput)
        {
            EntityRepository<Clients> value = new EntityRepository<Clients>();
            Clients client = new Clients();

            client.FirstNameClient = clientInput.FirstNameClient;
            client.LastNameClient = clientInput.LastNameClient;
            client.BirthDayClient = clientInput.BirthDayClient;
            client.GenreClient = clientInput.GenreClient;

            value.SaveOrUpdate(client);

            return Request.CreateResponse(HttpStatusCode.Created, "Client Enregistrer !");
        }

        [HttpPatch]
        [Route("api/clients/update")]
        public async Task<HttpResponseMessage> UpdateClient([FromUri] Guid idInput, [FromBody] ClientsReq clientInput)
        {
            EntityRepository<Clients> value = new EntityRepository<Clients>();

            var findClientId = await value.GetById(idInput);
            if (findClientId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Client introuvable, mise ajour impossible !");

            findClientId.FirstNameClient = clientInput.FirstNameClient;
            findClientId.LastNameClient = clientInput.LastNameClient;
            findClientId.BirthDayClient = clientInput.BirthDayClient;
            findClientId.GenreClient = clientInput.GenreClient;

            value.SaveOrUpdateAsynk(findClientId);
            return Request.CreateResponse(HttpStatusCode.OK, "Client Mise a Jour !");
        }

        [HttpDelete]
        [Route("api/clients/delete")]
        public async Task<HttpResponseMessage> DeleteClient ([FromUri] Guid idInput)
        {
            EntityRepository<Clients> value = new EntityRepository<Clients>();

            var findClientId = await value.GetById(idInput);
            if (findClientId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Client introuvable, mise ajour impossible !");

            await value.DeleteById(idInput);
            return Request.CreateResponse(HttpStatusCode.OK, "Client Effacer !");

        }
    }
}
