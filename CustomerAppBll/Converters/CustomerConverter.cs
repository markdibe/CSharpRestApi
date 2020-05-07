using CustomerAppBll.BusinessObjects;
using CustomerAppDAO.Entities;

namespace CustomerAppBll.Converters
{
    public class CustomerConverter
    {
        internal Customer Convert(CustomerBO cust)
        {
            if (cust == null) { return null; }
            Customer customer = new Customer()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address
            };
            return customer;
        }

        internal CustomerBO Convert(Customer cust)
        {
            if (cust == null) { return null; }
            CustomerBO customer = new CustomerBO()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address
            };
            return customer;
        }
    }
}

