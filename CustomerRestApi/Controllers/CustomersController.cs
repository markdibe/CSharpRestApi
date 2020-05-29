using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAppBll;
using CustomerAppBll.BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly BllFacade facade;
        public CustomersController()
        {
            facade = new BllFacade();
        }

        // GET: api/Customers
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(facade.CustomerService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(facade.CustomerService.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Customers
        [HttpPost]
        public IActionResult Post([FromBody] CustomerBO customer)
        {
            try
            {
                return Ok(facade.CustomerService.Create(customer));
            }
            catch(Exception e)
            {
                throw (e);
            }
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerBO UpdatedCustomer)
        {
            if (id == UpdatedCustomer.Id)
            {
                try
                {
                    

                }
                catch(Exception e)
                {
                    throw (e);
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
