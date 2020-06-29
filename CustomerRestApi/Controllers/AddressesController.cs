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
    [EnableCors("MyPolicy")]
    public class AddressesController : ControllerBase
    {
        private BllFacade facade;

        public AddressesController()
        {
            this.facade = new BllFacade();
            //facade = _facade;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<IActionResult> Get()

        {
            try
            {
                return Ok(facade.AddressService.GetAll().ToAsyncEnumerable());
            }
            catch (Exception e) { throw (e); }
        }

        // GET: api/Addresses/5
        [HttpGet("{id}", Name = "Get")]
        public AddressBO Get(int id)
        {
            return facade.AddressService.Get(id);
        }

        // POST: api/Addresses
        [HttpPost]
        public AddressBO Post([FromBody] AddressBO address)
        {
            return facade.AddressService.Create(address);
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
