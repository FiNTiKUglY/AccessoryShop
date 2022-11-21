using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_053505_Pronin.Data;
using WEB_053505_Pronin.Models;
using WEB_053505_Pronin.ExtestionMethods;

namespace WEB_053505_Pronin.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDBContext _context;
        private readonly Cart _cart;

        public CartController(AppDBContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Index()
        {
            return View(_cart);
        }

        public IActionResult Remove(int id, string returnUrl)
        {
            _cart.RemoveFromCart(id);
            return Redirect(returnUrl);
        }

        public IActionResult ClearAll(string returnUrl)
        {
            _cart.ClearAll();
            return Redirect(returnUrl);
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            var cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();
            var accessory = _context.Accessory.Find(id);
            if (accessory != null)
            {
                cart.AddToCart(accessory);
                HttpContext.Session.Set<Cart>("cart", cart);
            }
            return Redirect(returnUrl);
        }
    }
}
