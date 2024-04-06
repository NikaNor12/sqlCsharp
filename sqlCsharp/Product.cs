namespace sqlCsharp
{
    public class Product
    {
        public Product(string productID, string name, double price, bool isActive) 
        { 
            ProductID = productID;
            Name = name;
            Price = price;
            IsActive = isActive;
        }

        public string ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
    }
}