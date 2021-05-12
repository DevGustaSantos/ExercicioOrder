namespace Order.Entites
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; private set; }
        public Product Product { get; set; }

        public OrderItem(int quantity, double price ,Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal()
        {
            Price = Product.Price;
            return Price * Quantity;
        }
    }
}
