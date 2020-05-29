using CustomerAppBll.Services;
using CustomerAppDAO;
using System;

namespace CustomerAppBll
{
    public class BllFacade
    {
        private DalFacade facade;
        public BllFacade()
        {
            facade = new DalFacade();
        }

        public ICustomerService CustomerService { get { return new CustomerService(facade, new Converters.CustomerConverter()); } }
        public IOrderService OrderService { get { return new OrderService(facade); } }
        public IAddressService AddressService { get { return new AddressService(facade); } }
    }
}
