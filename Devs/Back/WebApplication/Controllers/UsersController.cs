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
        private EntityRepository<Users> _usersRepository = null;
        public UsersController(EntityRepository<Users> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost]
        [Route("api/users")]
        public async Task<HttpResponseMessage> GetAllUserss()
        {

            var listOfAllUserss = await _usersRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, listOfAllUserss);
        }

        [HttpGet]
        [Route("api/users")]
        public async Task<HttpResponseMessage> GetUsersById([FromUri] Guid IdInput)
        {

            var findUsersId = await _usersRepository.GetById(IdInput);

            if (findUsersId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "L'Id du users saisi n'existe pas !");

            return Request.CreateResponse(HttpStatusCode.OK, findUsersId);

        }

        [HttpPost]
        [Route("api/users/add")]
        public HttpResponseMessage AddUsers([FromBody] UsersReq usersInput)
        {
            Users users = new Users();

            users.FirstName = usersInput.FirstName;
            users.LastName = usersInput.LastName;
            users.Pseudo = usersInput.Pseudo;
            users.Email = usersInput.Email;
            users.PassWord = usersInput.PassWord;
/*
            users.Address = new AddressUserss
            {
                City = usersInput.AddressUsers.City,
                Country = usersInput.AddressUsers.Country,
                Quarter = usersInput.AddressUsers.Quarter,
                Street = usersInput.AddressUsers.Street,
                Batch = usersInput.AddressUsers.Batch,
                Postal_Code = usersInput.AddressUsers.Postal_Code,
            };

            users.Account = new Accounts
            {
                Pseudo = usersInput.AccountUsers.Pseudo,
                Email = usersInput.AccountUsers.Email,
                PassWord = usersInput.AccountUsers.PassWord,
            };*/

            try
            {
                _usersRepository.SaveOrUpdate(users);
                return Request.CreateResponse(HttpStatusCode.Created, "Users enregistré !");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Erreur lors de l'enregistrement du users : {e.Message}");
            }
        }

        [HttpPatch]
        [Route("api/users/update")]
        public async Task<HttpResponseMessage> UpdateUsers([FromUri] Guid idInput, [FromBody] UsersReq usersInput)
        {

            var findUsersId = await _usersRepository.GetById(idInput);
            if (findUsersId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Users introuvable, mise ajour impossible !");

            findUsersId.FirstName = usersInput.FirstName;
            findUsersId.LastName = usersInput.LastName;
            findUsersId.Pseudo = usersInput.Pseudo;
            findUsersId.Email = usersInput.Email;
            findUsersId.PassWord = usersInput.PassWord;

            _usersRepository.SaveOrUpdateAsynk(findUsersId);
            return Request.CreateResponse(HttpStatusCode.OK, "Users Mise a Jour !");
        }

        [HttpDelete]
        [Route("api/users/delete")]
        public async Task<HttpResponseMessage> DeleteUsers([FromUri] Guid idInput)
        {

            var findUsersId = await _usersRepository.GetById(idInput);
            if (findUsersId == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Users introuvable, mise ajour impossible !");

            await _usersRepository.DeleteById(idInput);
            return Request.CreateResponse(HttpStatusCode.OK, "Users Effacer !");

        }
    }
}
