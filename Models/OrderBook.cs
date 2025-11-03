using System.Collections.Generic;

namespace Inventory_system_1.Models
{
    public class OrderBook
    {
        public List<Order> QueuedOrders { get; } = new();
        public List<Order> ProcessedOrders { get; } = new();
        private double _totalRevenue;

        public void QueueOrder(Order order) => QueuedOrders.Add(order);

        public Order ProcessNextOrder(Inventory inventory)
        {
            if (QueuedOrders.Count == 0) return null;

            var order = QueuedOrders[0];
            QueuedOrders.RemoveAt(0);
            ProcessedOrders.Add(order);

            foreach (var line in order.OrderLines)
                inventory.UpdateStock(line.Item, line.Quantity);

            _totalRevenue += order.TotalPrice();
            return order;
        }

        public double TotalRevenue() => _totalRevenue;
    }
}