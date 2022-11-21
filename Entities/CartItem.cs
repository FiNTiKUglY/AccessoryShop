namespace WEB_053505_Pronin.Entities
{
    public class CartItem
    {
        public Accessory Item { get; set; }
        public int Count { get; set; }

        public CartItem(Accessory item)
        {
            Item = item;
            Count = 1;
        }
    }
}
