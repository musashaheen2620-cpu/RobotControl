using System.Collections.Generic;

namespace Inventory_system_1.Models
{
    public class Inventory
    {
        public Dictionary<Item, double> Stock { get; } = new();

        public void AddItem(Item item, double quantity)
        {
            if (Stock.ContainsKey(item))
                Stock[item] += quantity;
            else
                Stock[item] = quantity;
        }

        public void UpdateStock(Item item, double quantity)
        {
            if (Stock.ContainsKey(item))
            {
                Stock[item] -= quantity;
                if (Stock[item] < 0) Stock[item] = 0;
            }
        }
    }
}