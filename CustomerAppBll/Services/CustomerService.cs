using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppBll.BusinessObjects;
using CustomerAppBll.Converters;
using CustomerAppDAO;
using CustomerAppDAO.Entities;

namespace CustomerAppBll.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerConverter converter;
        private readonly DalFacade facade;

        public CustomerService(DalFacade facade, CustomerConverter converter)
        {
            this.facade = facade;
            this.converter = converter;
        }

        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Create(Convert(cust));
                uow.complete();
                return converter.Convert(newCust);
            }
        }

        public CustomerBO Delete(int id)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                var cust = uow.CustomerRepository.Delete(id);
                uow.complete();
                return converter.Convert(cust);
            }

        }

        public CustomerBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return converter.Convert(uow.CustomerRepository.Get(id));
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.CustomerRepository.GetAll().Select(x => Convert(x)).ToList();
            }
        }

        public CustomerBO Update(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customer = uow.CustomerRepository.Get(cust.Id);
                customer.FirstName = cust.FirstName;
                customer.LastName = cust.LastName;
                customer.Address = cust.Address;
                uow.complete();
                return converter.Convert(customer);
            }
        }


    }
}
