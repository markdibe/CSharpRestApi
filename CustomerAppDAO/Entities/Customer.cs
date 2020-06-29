using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAppDAO.Entities
{
    public class Customer
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public List<CustomerAddress> Addresses { get; set; }
        public List<Order> Orders { get; set; }

        [NotMapped]
        public virtual List<Address> DetailedAddresses { get; set; }

    }
}
