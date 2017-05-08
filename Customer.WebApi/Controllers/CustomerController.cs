using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerService.Entities;

namespace Customer.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public IEnumerable<CustomerService.Entities.Customer> Get()
        {
			var address = new Address("streetName", "city", "zip code", "country");
	        return new List<CustomerService.Entities.Customer> {new CustomerService.Entities.Customer("dfs", "dfd", "dfdf", address)};
        }

        // GET: api/Customer/5
        public CustomerService.Entities.Customer Get(int id)
        {
			var address = new Address("streetName", "city", "zip code", "country");
            return new CustomerService.Entities.Customer("dfs", "dfd", "dfdf", address);
        }

        // POST: api/Customer
        public void Post([FromBody]CustomerService.Entities.Customer value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]CustomerService.Entities.Customer value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
