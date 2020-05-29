using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IAddressRepository AddressRepository { get; }
        int complete();
    }
}
