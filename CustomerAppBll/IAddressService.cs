using CustomerAppBll.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBll
{
    public interface IAddressService
    {
        AddressBO Create(AddressBO address);

        AddressBO Delete(int id);

        AddressBO Update(AddressBO address);

        AddressBO Get(int id);

        List<AddressBO> GetAll();


    }
}
