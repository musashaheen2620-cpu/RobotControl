namespace Inventory_system_1.Models
{
    public class BulkItem : Item
    {
        public string MeasurementUnit { get; }

        public BulkItem(string name, double pricePerUnit, string measurementUnit)
        {
            Name = name;
            PricePerUnit = pricePerUnit;
            MeasurementUnit = measurementUnit;
        }
    }
}