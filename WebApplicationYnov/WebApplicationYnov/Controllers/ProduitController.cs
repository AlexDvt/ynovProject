using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationYnov.Controllers
{
    public class ProduitController : ApiController
    {
        // GET: api/Produit
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Produit/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Produit
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Produit/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Produit/5
        public void Delete(int id)
        {
        }
    }
}
