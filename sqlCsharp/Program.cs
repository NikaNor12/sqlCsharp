using Microsoft.Data.SqlClient;

namespace sqlCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line =
            {
                "Category 1\t0\t001\tProduct 1\t31.99\t0",
                "Category 1\t0\t002\tProduct 2\t13.99\t0",
                "Category 2\t1\t003\tProduct 3\t26.99\t0",
                "Category 3\t1\t004\tProduct 4\t65.99\t1",
                "Category 3\t1\t005\tProduct 5\t300.99\t1",
                "Category 4\t1\t006\tProduct 6\t700.99\t1",
                "Category 2\t1\t007\tProduct 7\t12.99\t1",
                "Category 5\t1\t008\tProduct 8\t42.99\t1",
                "Category 5\t1\t009\tProduct 9\t111.99\t1"
            };

            string insertCategory = "INSERT INTO Categories (Name, IsActive) VALUES (@Name, @IsActive)";
            string insertProduct = "INSERT INTO Products (CategoryID, Code, Name, Price, IsActive) VALUES (@CategoryID, @Code, @Name, @Price, @IsActive)";

            string connectionString = "Server=DESKTOP-FGUKH5T; Database=FirstAdonet; Integrated Security=true; TrustServerCertificate=true";

            ICollection<Category> categories = new List<Category>();

            IConnectionToSQL conn = new ConnectionToSQL(connectionString);
            conn.Connection();

            foreach (var item in line)
            {
                string[] parts = item.Split('\t');

                string categoryName = parts[0];
                bool isActive = parts[1] == "1";
                string productID = parts[2];
                string productName = parts[3];
                double price = double.Parse(parts[4]);
                bool IsActiveP = parts[5] == "1";

                Category category = new Category(categoryName, isActive);
                categories.Add(category);
                category.Products.Add(new Product(productID, productName, price, IsActiveP));

                try
                {
                    SqlCommand categoryCommand = new SqlCommand(insertCategory);
                    categoryCommand.Parameters.AddWithValue("@Name", categoryName);
                    categoryCommand.Parameters.AddWithValue("@IsActive", isActive);
                    categoryCommand.ExecuteNonQuery();


                    SqlCommand productCommand = new SqlCommand(insertProduct);
                    productCommand.Parameters.AddWithValue("@Code", productID);
                    productCommand.Parameters.AddWithValue("@Name", productName);
                    productCommand.Parameters.AddWithValue("@Price", price);
                    productCommand.Parameters.AddWithValue("@IsActive", IsActiveP);
                    productCommand.ExecuteNonQuery();
                    Console.WriteLine("Data inserted successfully.");
                }

                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WARNINNG!!! Data was not inserted" + "ERROR" + ex.Message);
                    Console.ResetColor();
                }
            }


            foreach (Category item in categories)
            {
                Console.WriteLine($"Category: {item.Name}, IsActive: {item.IsActive}");
                Console.WriteLine("Products: ");

                foreach (Product items in item.Products)
                {
                    Console.WriteLine($"\t{items.ProductID}, {items.Name}, {items.Price}, {items.IsActive}");
                }

                Console.WriteLine();
            }
        }
    }
}