using System;
using System.Collections.Generic;

// Class to represent an Address
public class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"{streetAddress}\n{city}, {state}\n{country}";
    }
}

// Class to represent a Customer
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string Name => name;
    public Address Address => address;
}

// Class to represent a Product
public class Product
{
    private string name;
    private string productId;
    private decimal pricePerUnit;
    private int quantity;

    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
    }

    public decimal TotalCost => pricePerUnit * quantity;
    public string Name => name;
    public string ProductId => productId;
}

// Class to represent an Order
public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal TotalCost
    {
        get
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.TotalCost;
            }
            total += customer.IsInUSA() ? 5 : 35;
            return total;
        }
    }

    public string PackingLabel
    {
        get
        {
            string label = "Packing Label:\n";
            foreach (var product in products)
            {
                label += $"{product.Name} ({product.ProductId})\n";
            }
            return label;
        }
    }

    public string ShippingLabel
    {
        get
        {
            return $"Shipping Label:\n{customer.Name}\n{customer.Address}";
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Maple Ave", "Othertown", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Widget", "W123", 10m, 2);
        Product product2 = new Product("Gadget", "G456", 20m, 1);
        Product product3 = new Product("Thingamajig", "T789", 5m, 5);
        Product product4 = new Product("Doohickey", "D012", 15m, 3);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display order details
        Console.WriteLine(order1.PackingLabel);
        Console.WriteLine(order1.ShippingLabel);
        Console.WriteLine($"Total Cost: ${order1.TotalCost}\n");

        Console.WriteLine(order2.PackingLabel);
        Console.WriteLine(order2.ShippingLabel);
        Console.WriteLine($"Total Cost: ${order2.TotalCost}\n");
    }
}
