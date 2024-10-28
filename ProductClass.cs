namespace ClassWork4.ProductClass
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; set; }

        public Product(int id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
