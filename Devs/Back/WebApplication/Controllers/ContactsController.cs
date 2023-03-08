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
    public class ContactsController : ApiController
    {
        private EntityRepository<Contacts> _contactsRepository = null;
        private EntityRepository<Clients> _clientsRepository = null;

        public ContactsController(
            EntityRepository<Contacts> contactsRepository,
            EntityRepository<Clients> clientsRepository
            )
        {
            _contactsRepository = contactsRepository;
            _clientsRepository = clientsRepository;
        }

        [HttpGet]
        [Route("api/contacts")]
        public async Task<HttpResponseMessage> GetAllContact()
        {
            var listOfContacts = await _contactsRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, listOfContacts);
        }

        [HttpPost]
        [Route("api/contacts/assign")]
        public async Task<HttpResponseMessage> AssignContact([FromUri] Guid idClient, [FromBody] ContactsReq contactsInput)
        {
            var findClient = await _clientsRepository.GetById(idClient);

            if (findClient == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Utilisateur Introuvable, impossible d'assigner de numéro");


            var constact = new Contacts
            {
                Phone = contactsInput.Phone,
                Email = contactsInput.Email,
                Client = findClient
            };

            findClient.Contact.Add(constact);

            _clientsRepository.SaveOrUpdate(findClient);

            return Request.CreateResponse(HttpStatusCode.OK, $"Contact Assigner à {findClient.FirstNameClient}");
        }
    }
}
