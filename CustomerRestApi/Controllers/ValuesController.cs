using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerAppBll;
using System.Net;

namespace CustomerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public BllFacade facade { get { return new BllFacade(); } }
        public ValuesController()
        {
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(facade.CustomerService.GetAll());
            }
            catch(Exception e)
            {
                return BadRequest("There is no customer in database or " + e.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(facade.CustomerService.Get(id));
            }
            catch
            {
                return BadRequest("Customer Not Existed");
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CustomerAppBll.BusinessObjects.CustomerBO customerBO)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(facade.CustomerService.Create(customerBO));
            }
            catch
            {
                return BadRequest("Could Not Create a Customer ");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerAppBll.BusinessObjects.CustomerBO cust)
        {
            if (id != cust.Id)
            {
                return BadRequest("The Id in the Url is different of the id in the object");
            }
            try
            {
                return Ok(facade.CustomerService.Update(cust));
            }
            catch(InvalidOperationException e)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, e.Message);
                //return BadRequest("Could not update a customer");
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(facade.CustomerService.Delete(id));
            }
            catch
            {
                return StatusCode(404, "customer not found or could");
            }
        }
    }
}
