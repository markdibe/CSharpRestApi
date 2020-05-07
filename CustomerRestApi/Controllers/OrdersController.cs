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
    public class OrdersController : ControllerBase
    {
        private readonly BllFacade facade;
        public OrdersController()
        {
            this.facade = new BllFacade();
        }
        // GET: api/Orders
        [HttpGet]
        public IEnumerable<OrderBo> Get()
        {
            return facade.OrderService.GetAll();
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "Get")]
        public OrderBo Get(int id)
        {
            return facade.OrderService.Get(id);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody] OrderBo order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(facade.OrderService.Create(order));
                }
                catch
                {
                    return BadRequest($"Could not add the new order : {order}");
                }
                
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderBo order)
        {
            if (id != order.Id)
            {
                return BadRequest("Id conflict between body and header!");
            }
            try
            {
                return Ok(facade.OrderService.Update(order));
            }
            catch
            {
                return BadRequest($"Could not update order of id: {order.Id}");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(facade.OrderService.Delete(id));
            }
            catch
            {
                return BadRequest($"Order Of Id : {id} not found !");
            }
        }
    }
}
