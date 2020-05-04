using CustomerAppBll.Services;
using CustomerAppDAO;
using System;

namespace CustomerAppBll
{
    public class BllFacade
    {
        public BllFacade()
        {

        }

        public ICustomerService CustomerService { get { return new CustomerService(new DalFacade()); } }

    }
}
