using System;
using System.Collections.Generic;
class Product
{
    public string Code;
    public string Name;
    public Product(string code, string name)
    {
        Code = code;
        Name = name;
    }
    public override bool Equals(object? obj)
    {
        if (obj is Product other)
            return Code == other.Code;

        return false;
    }
    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }
}
class Program
{
    static void Main()
    {
        List<Product> items = new List<Product>
        {
            new Product("A-100", "Кабель USB-C"),
            new Product("B-205", "Миша бездротова"),
            new Product("A-100", "Кабель USB-C"),
            new Product("C-310", "Клавіатура"),
            new Product("D-415", "Монітор 24 дюйми"),
            new Product("B-205", "Миша бездротова"),
            new Product("E-520", "Навушники"),
            new Product("F-630", "Вебкамера")
        };
        HashSet<Product> unique = new HashSet<Product>();
        foreach (Product p in items)
        {
            unique.Add(p);
        }
        Dictionary<Product, int> stock = new Dictionary<Product, int>();
        stock[new Product("A-100", "Кабель USB-C")] = 17;
        stock[new Product("A-100", "Кабель USB-C")] = 25;
        Product a = new Product("A-100", "Кабель USB-C");
        Product b = new Product("A-100", "Кабель USB-C");
        Console.WriteLine("Діагностика:");
        Console.WriteLine(a.Equals(b));
        Console.WriteLine(unique.Count);
        Console.WriteLine(unique.Contains(a));
        Console.WriteLine(stock.Count);
        Console.WriteLine(stock.ContainsKey(a));
        Console.WriteLine("\nАртикули зі списку:");
        foreach (Product p in unique)
        {
            Console.WriteLine(p.Code + " - " + p.Name);
        }
    }
}