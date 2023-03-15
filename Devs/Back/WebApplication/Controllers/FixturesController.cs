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
        [Route("api/fixtures/add")]
        public async Task<HttpResponseMessage> AddFixture()
        {
            try
            {
                FixtureHelpers fixture = new FixtureHelpers();
                await fixture.AddFixtures();

                return Request.CreateResponse(HttpStatusCode.OK, "Fixture Ajouter !");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
