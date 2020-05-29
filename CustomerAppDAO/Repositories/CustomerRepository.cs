using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAO.Context;
using CustomerAppDAO;
using CustomerAppDAO.Entities;

namespace CustomerAppDAO.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerAppContext _context;
        public CustomerRepository(CustomerAppContext context)
        {
            _context = context;
        }


        public Customer Create(Customer cust)
        {
            _context.Customers.Add(cust);
            //move to unit of work later !
            return cust;
        }

        public Customer Delete(int id)
        {
            var cust = Get(id);
            _context.Customers.Remove(cust);
            //move to uow
            return cust;
        }

        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
