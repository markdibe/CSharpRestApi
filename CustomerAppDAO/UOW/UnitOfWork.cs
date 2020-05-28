using CustomerAppDAO.Context;
using CustomerAppDAO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private CustomerAppContext _context;
        public ICustomerRepository CustomerRepository { get; internal set; }
        public IOrderRepository OrderRepository { get; internal set; }
        public IAddressRepository AddressRepository { get; internal set; }
        public UnitOfWork()
        {
            _context = new CustomerAppContext() ;
            CustomerRepository = new CustomerRepositoryEFMemory(_context);
            OrderRepository = new OrderRepository(_context);
            AddressRepository = new AddressRepository(_context);
        }
       

        public int complete()
        {
            // int return the number of objects underlined modified in database
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
