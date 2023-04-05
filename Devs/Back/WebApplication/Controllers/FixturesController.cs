using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication.Utils;

namespace WebApplication.Controllers
{
    public class FixturesController : ApiController
    {
        [HttpGet]
        [Route("api/fixtures/cardType")]
        public async Task<HttpResponseMessage> AddFixtureCardType()
        {
            try
            {
                FixtureHelpers fixture = new FixtureHelpers();
                await fixture.AddFixturesCardType();

                return Request.CreateResponse(HttpStatusCode.OK, "Fixture Ajouter !");
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [HttpGet]
        [Route("api/fixtures/role")]
        public async Task<HttpResponseMessage> AddFixtureRole()
        {
            try
            {
                FixtureHelpers fixture = new FixtureHelpers();
                await fixture.AddFixturesRole();

                return Request.CreateResponse(HttpStatusCode.OK, "Fixture Ajouter !");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
