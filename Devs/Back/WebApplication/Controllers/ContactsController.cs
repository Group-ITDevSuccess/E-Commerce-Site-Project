using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Business;
using WebApplication.Entity;

namespace WebApplication.Controllers
{
    public class ContactsController : ApiController
    {
        private EntityRepository<Contacts> _contactsRepository = null;

        public ContactsController(EntityRepository<Contacts> contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        [HttpGet]
        [Route("api/contacts")]
        public HttpResponseMessage GetAllContact()
        {
            var listOfContacts = _contactsRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, listOfContacts);
        }
    }
}
