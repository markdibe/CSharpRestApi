using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerAppBll.BusinessObjects
{
    public class CustomerBO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }

        public List<OrderBo> Orders { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public List<int> AddressesId { get; set; }

        public List<AddressBO> DetailedAddresses { get; set; }

    }
}
