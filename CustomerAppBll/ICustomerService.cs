using CustomerAppBll.BusinessObjects;
using CustomerAppDAO;
using CustomerAppDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBll
{
    /// <summary>
    /// Interface is just an set of rules without implementation
    /// </summary>
    public interface ICustomerService
    {
        
        //Create customer
        CustomerBO Create(CustomerBO cust);

        //Read Customer 
        List<CustomerBO> GetAll();
        CustomerBO Get(int id);

        //Update 
        CustomerBO Update(CustomerBO cust);

        //Delete
        CustomerBO Delete(int id);
    }
}
