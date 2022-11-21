using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WEB_053505_Pronin.Models;

namespace WEB_053505_Pronin.Components
{
    public class MenuComponent : ViewComponent
    {
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller="Accessory", Action="Index",
            Text="Каталог"},
            new MenuItem{ IsPage=true, Area="Admin", Page="/Index",
            Text="Администрирование"}
        };
        public IViewComponentResult Invoke()
        { 
            foreach (var menuItem in _menuItems)
            {

                if (menuItem.Controller == ViewContext.RouteData.Values["controller"]?.ToString()
                    && menuItem.Controller != null)
                {
                    menuItem.Active = "active";
                }
                else if (menuItem.Area == ViewContext.RouteData.Values["area"]?.ToString()
                        && menuItem.Area != null)
                {
                    menuItem.Active = "active";
                }
            }
            return View(_menuItems);
        }
    }
}
