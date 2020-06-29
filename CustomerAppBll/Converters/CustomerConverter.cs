using CustomerAppBll.BusinessObjects;
using CustomerAppDAO.Entities;
using System.Linq;
using CustomerAppBll.Converters;
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
                Address = cust.Address,
                Addresses = cust.AddressesId?.Select(x => new CustomerAddress() {
                    AddressId = x, CustomerId = cust.Id
                }).ToList()
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
                Address = cust.Address,
                AddressesId = cust.Addresses?.Select(x => x.AddressId).ToList(),
                DetailedAddresses = cust.DetailedAddresses?.Select(x=>new AddressConverter().Convert(x)).ToList()
            };
            return customer;
        }
    }
}

