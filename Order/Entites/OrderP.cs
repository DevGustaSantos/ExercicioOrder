using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Order.Entites.Enums;


namespace Order.Entites
{
    class OrderP
    {
        public DateTime Moment { get; private set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public OrderP(OrderStatus status, Client client)
        {
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem order)
        {
            Items.Add(order);
        }
        public void RemoveItem(OrderItem order)
        {
            Items.Remove(order);
        }

        public double Total()
        {
            double total = 0;
            foreach (OrderItem order in Items)
            {
                total += order.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY...");
            sb.Append($"Oder Moment...: {Moment.ToString("dd/MM/yyy - HH:mm:ss")}\n");
            sb.Append($"Order Status...: {Status.ToString()}\n\n");

            sb.AppendLine("CLIENT...");
            sb.Append($"Name...: {Client.Name}\n");
            sb.Append($"Birth Date...: {Client.BirthDate}\n");
            sb.Append($"Email...: {Client.Email}\n\n");

            sb.AppendLine($"ORDER ITEMS...");
            foreach(OrderItem orderItem in Items)
            {
                sb.Append($"Product...: {orderItem.Product.Name}\n");
                sb.Append($"Price...: {orderItem.Price.ToString("F2", CultureInfo.InvariantCulture)}\n");
                sb.Append($"Quantity...: {orderItem.Quantity}\n");
                sb.Append($"SubTotal...: {orderItem.SubTotal()}\n \n");
            }
            return sb.ToString();
        }
    }
}
