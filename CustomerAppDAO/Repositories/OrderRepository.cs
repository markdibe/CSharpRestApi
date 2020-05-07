using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAO.Context;
using CustomerAppDAO.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppDAO.Repositories
{
     class OrderRepository : IOrderRepository
    {

        private readonly CustomerAppContext _context;
        public OrderRepository(CustomerAppContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            if (order.Customer != null)
            {
                _context.Entry(order.Customer).State = EntityState.Unchanged;
            }
            _context.Orders.Add(order);
            return order;
        }

        public Order Delete(int id)
        {
            Order order = Get(id);
            _context.Orders.Remove(order);
            return order;
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
            //var list = (
            //    from order in _context.Orders
            //    join customer in _context.Orders on order.Id equals customer.Id
            //    select new
            //    {
                    
            //        FirstName = order.Customer.FirstName,
            //        LastName = order.Customer.LastName

            //    }
            //    ).ToList();
        }
    }
}
