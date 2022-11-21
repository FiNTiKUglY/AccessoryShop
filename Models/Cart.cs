using WEB_053505_Pronin.Entities;

namespace WEB_053505_Pronin.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public int Count { get => Items.Sum(item => item.Value.Count); }

        public double Cost { get => Items.Sum(item => item.Value.Count * item.Value.Item.Cost); }

        public virtual void AddToCart(Accessory item)
        {
            if (Items.ContainsKey(item.Id))
            {
                Items[item.Id].Count++;
            }
            else
            {
                Items.Add(item.Id, new CartItem(item));
            }
        }

        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
}
