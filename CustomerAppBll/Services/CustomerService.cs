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
                var newCust = uow.CustomerRepository.Create(converter.Convert(cust));
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
                return uow.CustomerRepository.GetAll().Select(x => converter.Convert(x)).ToList();
            }
        }

        public CustomerBO GetWithDetailedAddress(int id)
        {
            using(var uow = facade.UnitOfWork)
            {
                return converter.Convert(uow.CustomerRepository.GetWithDetailedAddress(id));
            }
        }

        public CustomerBO Update(CustomerBO Cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                Customer CustUpdated = converter.Convert(Cust);

                Customer CustFromDb = uow.CustomerRepository.Get(CustUpdated.Id);
                if (CustFromDb == null) { throw new InvalidOperationException("Customer Not Found !"); }
                //remove from customer Database the addresses does not exist in updated customer
                CustFromDb.Addresses
                    .RemoveAll(x => !CustUpdated.Addresses.Exists(ca => ca.AddressId == x.AddressId && ca.CustomerId == x.CustomerId));

                //remove from updated customer the addresses that already exists in database
                CustUpdated.Addresses.RemoveAll(x => CustFromDb.Addresses.Exists(ca => ca.AddressId == x.AddressId && ca.CustomerId == x.CustomerId));

                //add the rest of addresses that are new to customer address
                CustFromDb.Addresses.AddRange(CustUpdated.Addresses);

                uow.complete();

                return converter.Convert(CustFromDb);
            }
        }


    }
}
