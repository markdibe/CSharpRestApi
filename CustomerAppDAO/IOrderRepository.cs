using CustomerAppDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO
{
  public   interface IOrderRepository
    {
        Order Create(Order order);

        //Order Update(Order order);

        Order Delete(int id);

        Order Get(int id);

        List<Order> GetAll();
    }
}
