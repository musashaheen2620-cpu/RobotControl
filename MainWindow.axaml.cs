using Avalonia.Controls;
using Inventory_system_1.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Inventory_system_1.Views
{
    public partial class MainWindow : Window
    {
        private Inventory _inventory;
        private OrderBook _orderBook;
        private ItemSorterRobot _robot;

        public MainWindow()
        {
            InitializeComponent();

            _inventory = new Inventory();
            _orderBook = new OrderBook();
            _robot = new ItemSorterRobot();

            InitializeDemoData();

            // Her er ProcessButton, StatusMessages osv. automatisk forbundet via XAML
            ProcessButton.Click += async (_, _) => await ProcessOrderAsync();
            RefreshUI();
        }

        private void InitializeDemoData()
        {
            var item1 = new UnitItem("M3 screw", 1, 0.1) { InventoryLocation = 1 };
            var item2 = new UnitItem("M3 nut", 1.5, 0.1) { InventoryLocation = 2 };
            var item3 = new UnitItem("Pen", 1, 0.1) { InventoryLocation = 3 };

            _inventory.AddItem(item1, 100);
            _inventory.AddItem(item2, 100);
            _inventory.AddItem(item3, 100);

            var order1 = new Order(new List<OrderLine>
            {
                new OrderLine(item1, 1),
                new OrderLine(item2, 2),
                new OrderLine(item3, 1)
            });

            var order2 = new Order(new List<OrderLine>
            {
                new OrderLine(item2, 2)
            });

            var customer1 = new Customer("Ramanda");
            var customer2 = new Customer("Totoro");

            customer1.CreateOrder(_orderBook, order1);
            customer2.CreateOrder(_orderBook, order2);
        }

        private async Task ProcessOrderAsync()
        {
            StatusMessages.Text += "\nProcessing next order...";
            var order = _orderBook.ProcessNextOrder(_inventory);

            if (order == null)
            {
                StatusMessages.Text += "\nNo queued orders left!";
                return;
            }

            foreach (var line in order.OrderLines)
            {
                for (int i = 0; i < line.Quantity; i++)
                {
                    StatusMessages.Text +=
                        $"\nPicking up {line.Item.Name} (location {line.Item.InventoryLocation})...";
                    _robot.PickUp(line.Item.InventoryLocation);
                    await Task.Delay(9500);
                }
            }

            StatusMessages.Text += "\nOrder completed. Shipment box ready!";
            RefreshUI();
        }

        private void RefreshUI()
        {
            var queued = new List<string>();
            foreach (var order in _orderBook.QueuedOrders)
                queued.Add($"{order.GetOrderDescription()} | {order.Time:MM/dd/yyyy hh:mm:ss tt}");

            var processed = new List<string>();
            foreach (var order in _orderBook.ProcessedOrders)
                processed.Add($"{order.GetOrderDescription()} | {order.Time:MM/dd/yyyy hh:mm:ss tt}");

            QueuedOrdersList.ItemsSource = queued;
            ProcessedOrdersList.ItemsSource = processed;
            RevenueText.Text = $"{_orderBook.TotalRevenue():0.00} DKK";
        }
    }
}
