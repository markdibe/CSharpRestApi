using CustomerAppBll.BusinessObjects;
using CustomerAppDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBll.Converters
{
    internal class AddressConverter
    {
        internal Address Convert(AddressBO addressBO)
        {
            if (addressBO == null) { return null; };
            return new Address()
            {
                City = addressBO.City,
                Id = addressBO.Id,
                Number = addressBO.Number,
                Street = addressBO.Street
            };
        }

        internal AddressBO Convert(Address address)
        {
            return new AddressBO()
            {
                City = address.City,
                Street = address.Street,
                Number = address.Number,
                Id = address.Id
            };
        }
    }
}
