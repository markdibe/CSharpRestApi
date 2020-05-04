using CustomerAppDAO.Repositories;
using CustomerAppDAO.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO
{
    public class DalFacade
    {
        //public ICustomerRepository CustomerRepository
        //{
        //    //get { return new CustomerRepositoyFakeDB(); }
        //    get { return new CustomerRepositoryEFMemory(new Context.InMemoryContext()); }
        //}

        public IUnitOfWork UnitOfWork
        {
            get { return new UnitOfWorkMem(); }
        }
    }
}
