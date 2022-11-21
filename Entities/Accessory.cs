namespace WEB_053505_Pronin.Entities
{
    public class Accessory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public double Cost { get; set; }
        public string Image { get; set; }
    }
}
