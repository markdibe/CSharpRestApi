using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAO;
using CustomerAppDAO.Entities;

namespace CustomerAppDAO.Repositories
{
    class CustomerRepositoyFakeDB : ICustomerRepository
    {
        #region FakeDB
        public static int id = 1;
        public static List<Customer> customers = new List<Customer>();
        #endregion

        #region I do not kno why we get the code of service here
        public Customer Create(Customer cust)
        {
            Customer newCust;
            customers.Add(newCust = new Customer()
            {
                Id = id++,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address
            });
            return newCust;
        }

        public Customer Delete(int id)
        {
            Customer customer = Get(id);
            customers.Remove(customer);
            return customer;
        }

        public Customer Get(int id)
        {
            return customers.FirstOrDefault(x => x.Id == id);
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(customers.ToList());
        }

        public Customer Update(Customer cust)
        {
            Customer customer = Get(cust.Id);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found");
            }
            customer.FirstName = cust.FirstName;
            customer.LastName = cust.LastName;
            customer.Address = cust.Address;
            return customer;
        }

        #endregion


      
    }
}
