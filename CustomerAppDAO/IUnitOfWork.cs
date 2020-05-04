using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        int complete();
    }
}
