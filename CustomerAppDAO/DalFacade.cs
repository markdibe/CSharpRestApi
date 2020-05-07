using CustomerAppDAO.Repositories;
using CustomerAppDAO.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO
{
    public class DalFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get { return new UnitOfWork(); }
        }
    }
}
