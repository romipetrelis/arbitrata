using System.Collections.Generic;
using KnockoutWebForms.Models;

namespace KnockoutWebForms.Services
{
    internal class AddressService : IAddressService
    {
        public IEnumerable<AddressModel> GetAddresses()
        {
            return AddressModelFaker.FakeEnumerable();
        }
    }
}