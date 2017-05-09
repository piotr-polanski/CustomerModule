using System.Collections.Generic;
using System.Web.Http;
using Customer.WebApi.Filters;
using CustomerService;

namespace Customer.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
	    private readonly ICustomerService _customerService;

	    public CustomerController(CustomerService.ICustomerService customerService)
	    {
		    _customerService = customerService;
	    }
        // GET: api/Customer
        public IEnumerable<CustomerService.Entities.Customer> Get()
        {
	        return _customerService.GetAll();
        }

        // GET: api/Customer/5
        public CustomerService.Entities.Customer Get(int id)
        {

	        return _customerService.GetById(id);
        }

        // POST: api/Customer
        public void Post([FromBody]CustomerService.Entities.Customer customer)
        {
			_customerService.Create(customer);
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]CustomerService.Entities.Customer customer)
        {
			_customerService.Update(id, customer);
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
			_customerService.Delete(id);
        }
    }
}
