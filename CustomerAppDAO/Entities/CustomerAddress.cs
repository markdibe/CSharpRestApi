using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO.Entities
{
    public class CustomerAddress
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
