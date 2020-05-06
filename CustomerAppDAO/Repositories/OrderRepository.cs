using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAO.Context;
using CustomerAppDAO.Entities;

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
        }
    }
}
