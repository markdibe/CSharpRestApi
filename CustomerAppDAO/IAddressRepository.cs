using CustomerAppDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO
{
   public interface IAddressRepository
    {
        Address Create(Address address);

        Address Delete(int id);

        Address Get(int id);

        IEnumerable<Address> GetAll();

        IEnumerable<Address> GetAllById(List<int> Ids);
    }
}
