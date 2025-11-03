namespace Inventory_system_1.Models
{
    public class UnitItem : Item
    {
        public double Weight { get; }

        public UnitItem(string name, double pricePerUnit, double weight)
        {
            Name = name;
            PricePerUnit = pricePerUnit;
            Weight = weight;
        }

        public UnitItem() { }
    }
}