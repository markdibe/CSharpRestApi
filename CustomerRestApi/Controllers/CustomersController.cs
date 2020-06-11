using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAppBll;
using CustomerAppBll.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyName = "MyPolicy")]
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
        public IActionResult Put(int id, [FromBody] CustomerBO UpdatedCustomer)
        {
            if (id == UpdatedCustomer.Id)
            {
                try
                {
                    return Ok(facade.CustomerService.Update(UpdatedCustomer));
                }
                catch(Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(facade.CustomerService.Delete(id));
            }
            catch(Exception e)
            {
                 return BadRequest(e.Message);
            }
        }
    }
}
