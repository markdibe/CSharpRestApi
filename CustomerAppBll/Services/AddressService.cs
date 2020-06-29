using CustomerAppBll.BusinessObjects;
using CustomerAppBll.Converters;
using CustomerAppDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerAppBll.Services
{
    public class AddressService :IAddressService
    {
        AddressConverter conv;
        DalFacade facade;

        public AddressService(DalFacade _facade)
        {
            conv = new AddressConverter();
            facade = _facade; 
        }

        public AddressBO Create(AddressBO address)
        {
             using(var uow = facade.UnitOfWork)
            {
                var _address = uow.AddressRepository.Create(conv.Convert(address));
                uow.complete();
                return conv.Convert(_address) ;
            }
        }

        public AddressBO Delete(int id)
        {
            AddressBO addressBO = Get(id);
            using(var uow = facade.UnitOfWork)
            {
                uow.AddressRepository.Delete(id);
                uow.complete();
            }
            return addressBO;
        }

        public AddressBO Get(int id)
        {
            using(var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.AddressRepository.Get(id));
            }
        }

        public List<AddressBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.AddressRepository.GetAll().Select(x => conv.Convert(x)).ToList();
            }
        }

        

        public AddressBO Update(AddressBO address)
        {
            using(var uow = facade.UnitOfWork)
            {
                var ad = uow.AddressRepository.Get(address.Id);
                address.City = ad.City;
                address.Number = ad.Number;
                address.Street = ad.Street;
                uow.complete();
                return conv.Convert(ad);
            }
        }
    }
}
