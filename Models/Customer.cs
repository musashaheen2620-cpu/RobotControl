using System.Collections.Generic;

namespace Inventory_system_1.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Order> Orders { get; } = new();

        public Customer(string name)
        {
            Name = name;
        }

        public void CreateOrder(OrderBook orderBook, Order order)
        {
            Orders.Add(order);
            orderBook.QueueOrder(order);
        }
    }
}