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
using WebApplication.Enum;

namespace WebApplication.Controllers
{
    public class RolesController : ApiController
    {
        private EntityRepository<Role> _rolesRepository = null;
        private EntityRepository<Users> _usersRepository = null;
        public RolesController
        (
            EntityRepository<Role> roleTypesRepository,
            EntityRepository<Users> userRepository
        )
        {
            _rolesRepository = roleTypesRepository;
            _usersRepository = userRepository;
        }

        [HttpPost]
        [Route("api/roles")]
        public async Task<HttpResponseMessage> GetAllRole()
        {
            var allRole = await _rolesRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allRole);
        }


        [HttpPost]
        [Route("api/roles/user")]
        public async Task<HttpResponseMessage> AssignCardClient([FromBody] RoleReq roleReq, [FromUri] Guid idUser)
        {
            var userSpecific = await _usersRepository.GetById(idUser);

            if (userSpecific == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"User introuvable");

            List<Role> roles = new List<Role>();

            /*userSpecific.Role = new List<Role>();*/

            foreach (UserRoleEnum item in roleReq.Role)
            {
                Role role = ((RolesRepository)_rolesRepository).FindRolesByName(item);
                roles.Add(role);
            }

            userSpecific.Role = roles;

            _usersRepository.SaveOrUpdate(userSpecific);
            return Request.CreateErrorResponse(HttpStatusCode.OK, "Roles attribuer a au user !");
        }
    }
}
