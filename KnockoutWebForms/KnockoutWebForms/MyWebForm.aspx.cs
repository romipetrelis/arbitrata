using System.Linq;
using System.Web.Services;
using KnockoutWebForms.Models;

namespace KnockoutWebForms
{
    public partial class MyWebForm : System.Web.UI.Page
    {
        [WebMethod]
        public static SuperheroModel[] GetSuperheroesWrapper(bool caped)
        {
            var svc = new SuperheroService();
            return svc.GetSuperheroes().Where(h => h.IsCaped == caped).ToArray();
        } 
    }
}