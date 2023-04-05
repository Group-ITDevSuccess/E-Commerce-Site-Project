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
        private EntityRepository<Users> _usersRepository = null;

        public ContactsController(
            EntityRepository<Contacts> contactsRepository,
            EntityRepository<Users> usersRepository
            )
        {
            _contactsRepository = contactsRepository;
            _usersRepository = usersRepository;
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
        public async Task<HttpResponseMessage> AssignContact([FromUri] Guid idUser, [FromBody] ContactsReq contactsInput)
        {
            Console.WriteLine(idUser);
            var findUser = await _usersRepository.GetById(idUser);

            if (findUser == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Utilisateur Introuvable, impossible d'assigner de numéro");


            var constact = new Contacts
            {
                Phone = contactsInput.Phone,
                DateCreation = contactsInput.DateCreation,
                User = findUser
            };

            findUser.Contact.Add(constact);

            _usersRepository.SaveOrUpdate(findUser);

            return Request.CreateResponse(HttpStatusCode.OK, $"Contact Assigner à {findUser.FirstName}");
        }
    }
}
