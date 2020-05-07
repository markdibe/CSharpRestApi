using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppBll.BusinessObjects;
using CustomerAppBll.Converters;
using CustomerAppDAO;

namespace CustomerAppBll.Services
{
    class OrderService : IOrderService
    {
        private readonly CustomerAppDAO.DalFacade facade;
        OrderConverter converter = new OrderConverter();

        public OrderService(DalFacade facade)
        {
            this.facade = facade;
        }
        public OrderBo Create(OrderBo order)
        {
            using(var uow = facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Create(converter.convert(order));
                uow.complete();
                return converter.convert(orderEntity);
            }
        }

        public OrderBo Delete(int id)
        {
            using(var uow = facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Delete(id);
                uow.complete();
                return converter.convert(orderEntity);
            }
        }

        public OrderBo Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return converter.convert(uow.OrderRepository.Get(id));
            }
        }

        public List<OrderBo> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.OrderRepository.GetAll().Select(x=>converter.convert(x)).ToList();
            }
        }

        public OrderBo Update(OrderBo order)
        {
            using(var uow = facade.UnitOfWork)
            {
                var dbOrder = uow.OrderRepository.Get(order.Id);
                if (dbOrder == null)
                {
                    throw new InvalidOperationException("Order Not Found!");
                }
                dbOrder.OrderDate = order.OrderDate;
                dbOrder.DeliveryTime = order.DeliveryTime;
                uow.complete();
                return converter.convert(dbOrder);
            }
        }
    }
}
