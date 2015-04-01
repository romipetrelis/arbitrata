using System.Collections.Generic;
using KnockoutWebForms.Models;

namespace KnockoutWebForms.Services
{
    public interface IAddressService
    {
        IEnumerable<AddressModel> GetAddresses();
    }
}
