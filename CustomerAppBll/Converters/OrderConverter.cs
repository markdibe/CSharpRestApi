using CustomerAppBll.BusinessObjects;
using CustomerAppDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBll.Converters
{
    internal class OrderConverter
    {
        internal OrderBo convert(Order o)
        {
            if (o == null) { return null; }
            OrderBo order = new OrderBo()
            {
                DeliveryTime = o.DeliveryTime,
                Id = o.Id,
                OrderDate = o.OrderDate,
                Customer = new CustomerConverter().Convert(o.Customer),
                CustomerId = o.CustomerId
            };
            return order;
        }


        internal Order convert(OrderBo o)
        {
            if (o == null) { return null; }
            Order order = new Order()
            {
                DeliveryTime = o.DeliveryTime,
                Id = o.Id,
                OrderDate = o.OrderDate,
                Customer = new CustomerConverter().Convert(o.Customer),
                CustomerId = o.CustomerId
            };
            return order;
        }
    }
}
