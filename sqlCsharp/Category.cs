namespace sqlCsharp
{
    public class Category 
    {
        public Category(string name, bool isActive)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IsActive = isActive;
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}