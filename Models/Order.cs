using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory_system_1.Models
{
    public class Order
    {
        public DateTime Time { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new();

        public Order() { }

        public Order(List<OrderLine> orderLines)
        {
            Time = DateTime.Now;
            OrderLines = orderLines;
        }

        public double TotalPrice() =>
            OrderLines.Sum(line => line.Item.PricePerUnit * line.Quantity);

        public string GetOrderDescription()
        {
            var parts = new List<string>();
            foreach (var line in OrderLines)
                parts.Add($"{line.Item.Name} x {line.Quantity}");
            return string.Join(", ", parts);
        }
    }
}