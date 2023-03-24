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
    public class InfoUsersController : ApiController
    {
        private EntityRepository<InfoUsers> _infoUsersRepository = null;
        private EntityRepository<Users> _usersRepository = null;

        public InfoUsersController(
            EntityRepository<InfoUsers> infoUsersRepository,
            EntityRepository<Users> usersRepository
            )
        {
            _infoUsersRepository = infoUsersRepository;
            _usersRepository = usersRepository;
        }

        [HttpGet]
        [Route("api/info_user")]
        public async Task<HttpResponseMessage> GetAllInfoUser()
        {
            var allInfoUsers = await _infoUsersRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allInfoUsers);
        }

        [HttpPost]
        [Route("api/info_user/assign")]
        public async Task<HttpResponseMessage> AssignInfo([FromUri] Guid idUsers, [FromBody] InfoUsersReq InfoUsersInput)
        {
            var userSpecific = await _usersRepository.GetById(idUsers);
            if (userSpecific == null) return Request.CreateResponse(HttpStatusCode.NotFound, "User selectionner n'existe pas !");

            var info = new InfoUsers
            {
                Contact = InfoUsersInput.Contact,
                Mail = InfoUsersInput.Mail,
                Web = InfoUsersInput.Web,
                User = userSpecific
            };

            userSpecific.Info = new List<InfoUsers> ();
            userSpecific.Info.Add(info);
            _usersRepository.SaveOrUpdate(userSpecific);


            return Request.CreateResponse(HttpStatusCode.OK, "Info enregistrer !");
        }
    }
}
