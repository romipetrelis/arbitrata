using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using KnockoutWebForms.Models;
using KnockoutWebForms.Services;

namespace KnockoutWebForms.ViewModels
{
    public class OrderViewModel
    {
        private readonly IAddressService _addressService;

        public IReadOnlyCollection<AddressModel> AvailableAddresses { get; private set; }
        public AddressModel NewAddress { get; private set; }
        public IReadOnlyCollection<StateProvinceModel> AvailableStates { get; private set; }
        public string SelectedAddressType { get; set; }
        public AddressModel SelectedAddress { get; set; }
        public StateProvinceModel SelectedStateProvince { get; set; }

        public OrderViewModel(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public void Init()
        {
            NewAddress = new AddressModel();
            AvailableAddresses = new ReadOnlyCollection<AddressModel>(_addressService.GetAddresses().ToList());
            AvailableStates = new[]
            {
                new StateProvinceModel{Abbreviation = "IL", Country = "US", FullName="Illinois"},
                new StateProvinceModel{Abbreviation = "OH", Country = "US", FullName="Ohio"},
                new StateProvinceModel{Abbreviation = "WI", Country = "US", FullName="Wisconsin"},
                new StateProvinceModel{Abbreviation = "IN", Country = "US", FullName="Indiana"}
            };
            SelectedAddressType = "existing";
        }
    }
}