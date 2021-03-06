﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO.Entities
{
    public class Order
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryTime { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
