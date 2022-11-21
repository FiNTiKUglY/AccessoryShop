using Microsoft.AspNetCore.Mvc;
using WEB_053505_Pronin.Entities;
using WEB_053505_Pronin.Models;

namespace WEB_053505_Pronin.Components
{
    public class CartComponent : ViewComponent
    {
        private Cart _cart;
        public CartComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
