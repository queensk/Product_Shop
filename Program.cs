using System;
using System.Linq;
using Product_Shop.Models;

class Program
{
    static void Main(string[] args)
    {
        // Create a new product object
        var product = new Product
        {
            Name = "Laptop",
            Price = 999.99m
        };

        // Insert the product into the database
        using (var db = new ProductContext())
        {
            db.Products.Add(product);
            db.SaveChanges();
            Console.WriteLine($"Inserted product with id {product.Id}");
        }

        // Query the product from the database by name
        using (var db = new ProductContext())
        {
            var query = from p in db.Products
                        where p.Name == "Laptop"
                        select p;
            var result = query.FirstOrDefault();
            if (result != null)
            {
                Console.WriteLine($"Found product with id {result.Id}");
            }
            else
            {
                Console.WriteLine("No product found");
            }
        }

        // Update the product's price in the database
        using (var db = new ProductContext())
        {
            product.Price = 899.99m;
            db.Products.Update(product);
            db.SaveChanges();
            Console.WriteLine($"Updated product with id {product.Id}");
        }

        // Delete the product from the database
        using (var db = new ProductContext())
        {
            db.Products.Remove(product);
            db.SaveChanges();
            Console.WriteLine($"Deleted product with id {product.Id}");
        }
    }
}
