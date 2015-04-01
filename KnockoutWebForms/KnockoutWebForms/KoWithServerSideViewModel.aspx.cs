using System;
using KnockoutWebForms.Services;
using KnockoutWebForms.ViewModels;
using Newtonsoft.Json;

namespace KnockoutWebForms
{
    public partial class KoWithServerSideViewModel : System.Web.UI.Page
    {
        public OrderViewModel Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            //TODO: rely on DI instead of initializing the dependency here
            Model = new OrderViewModel(new AddressService());
            Model.Init();
        }

        protected void OnSaveButtonClick(object sender, EventArgs e)
        {
            var updates = JsonConvert.DeserializeObject<OrderViewModel>(jsonFromClient.Value);

            Model.SelectedAddress = updates.SelectedAddress;
            Model.SelectedAddressType = updates.SelectedAddressType;
            Model.SelectedStateProvince = updates.SelectedStateProvince;
        }
    }
}