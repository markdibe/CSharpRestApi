using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerAppBll.BusinessObjects
{
    public class CustomerBO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
