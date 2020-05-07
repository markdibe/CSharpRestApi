using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBll.BusinessObjects
{
   public class OrderBo
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryTime { get; set; }

        public int CustomerId { get; set; }
        public CustomerBO Customer { get; set; }
    }
}
