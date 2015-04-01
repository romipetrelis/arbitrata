using System;
using KnockoutWebForms.Services;
using KnockoutWebForms.ViewModels;

namespace KnockoutWebForms
{
    public partial class KoWithServerSideViewModel : System.Web.UI.Page
    {
        public OrderViewModel Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: rely on DI instead of initializing the dependency here
            Model = new OrderViewModel(new AddressService());
            Model.Init();
        }
    }
}