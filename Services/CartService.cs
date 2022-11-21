using System.Text.Json.Serialization;
using WEB_053505_Pronin.Entities;
using WEB_053505_Pronin.ExtestionMethods;
using WEB_053505_Pronin.Models;

namespace WEB_053505_Pronin.Services
{
    public class CartService : Cart
    {
        private static string sessionKey = "cart";
        [JsonIgnore]
        ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider sp)
        {
            var session = sp.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
            var cart = session?.Get<CartService>(sessionKey) ?? new CartService();
            cart.Session = session;
            return cart;
        }

        public override void AddToCart(Accessory accessory)
        {
            base.AddToCart(accessory);
            Session?.Set<CartService>(sessionKey, this);
        }
        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>(sessionKey, this);
        }
        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set<CartService>(sessionKey, this);
        }
    }
}
