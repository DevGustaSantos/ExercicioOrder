using System;
using System.Globalization;
using Order.Entites;
using Order.Entites.Enums;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to program...\n");

            Console.WriteLine("Enter Client Data...");
            Console.Write("Name...: ");
            string name = Console.ReadLine();
            Console.Write("Email...: ");
            string email = Console.ReadLine();
            Console.Write("Birth Day (DD/MM/YYY)...: ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDay);

            
            Console.WriteLine();//Jump a line in execution.

            Console.WriteLine("Enter order data....");
            Console.Write("Status...: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            
            Console.WriteLine();//Jump a line in execution.

            Console.Write("How many items to this order? ...: ");
            int qtdOrderItems = int.Parse(Console.ReadLine());

            OrderP orderP = new OrderP(status, client);

            for(int i = 1; i <= qtdOrderItems; i++)
            {
                Console.WriteLine($"Enter {i} item data...");
                Console.Write("Product name...: ");
                string pName = Console.ReadLine();
                Console.Write("Product price...: ");
                double pPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity...: ");
                int pQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(pName, pPrice);
                OrderItem orderItem = new OrderItem(pQuantity, pPrice ,product);
                orderP.AddItem(orderItem);

                Console.WriteLine();//Jump a line in execution
            }
            Console.WriteLine(orderP);
            Console.WriteLine($"TOTAL: {orderP.Total().ToString("F2")}");
        }
    }
}
