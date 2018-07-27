using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminApps.Api.Admin
{
    public class AdminDashboardController : ApiController
    {
        // GET: api/AdminDashboard
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AdminDashboard/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AdminDashboard
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AdminDashboard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AdminDashboard/5
        public void Delete(int id)
        {
        }
    }
}
