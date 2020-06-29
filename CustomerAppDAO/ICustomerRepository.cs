using CustomerAppDAO;
using CustomerAppDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO
{
    public interface ICustomerRepository
    {
        //Create customer
        Customer Create(Customer cust);

        //Read Customer 
        List<Customer> GetAll();
        Customer Get(int id);

      
        //Delete
        Customer Delete(int id);

        Customer GetWithDetailedAddress(int id);
    }
}
