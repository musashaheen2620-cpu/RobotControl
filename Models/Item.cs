namespace Inventory_system_1.Models
{
    public class Item
    {
        public string Name { get; set; }
        public double PricePerUnit { get; set; }
        public uint InventoryLocation { get; set; }
    }
}