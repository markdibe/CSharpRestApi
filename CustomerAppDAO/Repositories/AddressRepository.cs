using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAO.Context;
using CustomerAppDAO.Entities;

namespace CustomerAppDAO.Repositories
{
    class AddressRepository : IAddressRepository
    {
        private readonly CustomerAppContext _context;
        public AddressRepository(CustomerAppContext context)
        {
            _context = context;
        }


        public Address Create(Address address)
        {
            try
            {
                _context.Addresses.Add(address);
                return address;
            }
            catch (Exception e) { throw (e); }
        }

        public Address Delete(int id)
        {
            Address address = Get(id);
            try
            {
                _context.Addresses.Remove(address);
                return address;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public Address Get(int id)
        {
            try
            {
                return _context.Addresses.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses;
        }

        public IEnumerable<Address> GetAllById(List<int> ids)
        {
            return _context.Addresses.Where(x => ids.Contains(x.Id));
        }
    }
}
