using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationYnov.Controllers
{
    public class FactureController : ApiController
    {
        // GET: api/Facture
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Facture/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Facture
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Facture/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Facture/5
        public void Delete(int id)
        {
        }
    }
}
