using CustomerAppBll.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBll
{
    public interface IOrderService
    {
        OrderBo Create(OrderBo order);

        OrderBo Update(OrderBo order);

        OrderBo Delete(int id);

        OrderBo Get(int id);

        List<OrderBo> GetAll();
    }
}
