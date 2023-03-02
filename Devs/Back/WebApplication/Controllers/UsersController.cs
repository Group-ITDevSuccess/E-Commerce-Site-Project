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
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        public async Task<HttpResponseMessage> GetAllUsers()
        {
            EntityRepository<Users> value = new EntityRepository<Users>();

            var listOfAllUsers = await value.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, listOfAllUsers);
        }

        [HttpGet]
        [Route("api/user")]
        public async Task<HttpResponseMessage> GetUserById([FromUri] Guid IdInput)
        {
            EntityRepository<Users> value = new EntityRepository<Users>();

            var findUserId = await value.GetById(IdInput);

            if (findUserId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "L'Id de l'Utilisateur sais n'existe pas !");

            return Request.CreateResponse(HttpStatusCode.OK, findUserId);

        }

        [HttpPost]
        [Route("api/user/add")]
        public HttpResponseMessage AddUsers([FromBody] UsersReq userInput)
        {
            EntityRepository<Users> value = new EntityRepository<Users>();
            Users user = new Users();

            user.FirstNameUser = userInput.FirstNameUser;
            user.LastNameUser = userInput.LastNameUser;
            user.BirthDayUser = userInput.BirthDayUser;
            user.GenreUser = userInput.GenreUser;

            value.SaveOrUpdate(user);

            return Request.CreateResponse(HttpStatusCode.Created, "Utilisateur Enregistrer !");
        }

        [HttpPatch]
        [Route("api/user/update")]
        public async Task<HttpResponseMessage> UpdateUser([FromUri] Guid idInput, [FromBody] UsersReq userInput)
        {
            EntityRepository<Users> value = new EntityRepository<Users>();

            var findUserId = await value.GetById(idInput);
            if (findUserId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Utilisateur introuvable, mise ajour impossible !");

            findUserId.FirstNameUser = userInput.FirstNameUser;
            findUserId.LastNameUser = userInput.LastNameUser;
            findUserId.BirthDayUser = userInput.BirthDayUser;
            findUserId.GenreUser = userInput.GenreUser;

            value.SaveOrUpdateAsynk(findUserId);
            return Request.CreateResponse(HttpStatusCode.OK, "Utilisateur Mise a Jour !");
        }

        [HttpDelete]
        [Route("api/user/delete")]
        public async Task<HttpResponseMessage> DeleteUser ([FromUri] Guid idInput)
        {
            EntityRepository<Users> value = new EntityRepository<Users>();

            var findUserId = await value.GetById(idInput);
            if (findUserId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Utilisateur introuvable, mise ajour impossible !");

            await value.DeleteById(idInput);
            return Request.CreateResponse(HttpStatusCode.OK, "Utilisateur Effacer !");

        }
    }
}
