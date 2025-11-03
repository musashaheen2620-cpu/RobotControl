namespace Inventory_system_1.Models
{
    public class OrderLine
    {
        public Item Item { get; set; }
        public double Quantity { get; set; }

        public OrderLine() { }

        public OrderLine(Item item, double quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}