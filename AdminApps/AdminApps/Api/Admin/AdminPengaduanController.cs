using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminApps.Api.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminPengaduanController : ApiController
    {
        // GET: api/AdminPengaduan
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AdminPengaduan/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AdminPengaduan
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AdminPengaduan/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AdminPengaduan/5
        public void Delete(int id)
        {
        }
    }
}
