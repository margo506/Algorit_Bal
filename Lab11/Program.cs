using System;
using System.Collections.Generic;
using System.Text;
class Node
{
    public string Title;
    public List<Node> Children;
    public Node(string title, List<Node> children)
    {
        Title = title;
        Children = children;
    }
}
class Program
{
    static int callCount = 0;
    static Node menu = new Node("Головне меню", new List<Node>
    {
        new Node("Файл", new List<Node>
        {
            new Node("Новий", new List<Node>()),
            new Node("Зберегти", new List<Node>())
        }),
        new Node("Правка", new List<Node>
        {
            new Node("Копіювати", new List<Node>())
        }),
        new Node("Вигляд", new List<Node>
        {
            new Node("Масштаб", new List<Node>
            {
                new Node("Збільшити", new List<Node>()),
                new Node("Зменшити", new List<Node>())
            })
        }),
        new Node("Довідка", new List<Node>())
    });
    static void PrintMenu(Node node, int level)
    {
        Console.WriteLine(new string(' ', level * 2) + node.Title);
        foreach (Node child in node.Children)
        {
            PrintMenu(child, level + 1);
        }
    }
    static int CountItems(Node node)
    {
        callCount++;
        int count = 1;
        foreach (Node child in node.Children)
        {
            count += CountItems(child);
        }
        return count;
    }
    static bool Find(Node node, string name)
    {
        if (node.Title == name)
        {
            return true;
        }
        foreach (Node child in node.Children)
        {
            if (Find(child, name))
            {
                return true;
            }
        }
        return false;
    }
    static void Main()
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Ієрархія меню:");
        PrintMenu(menu, 0);
        Console.WriteLine();
        int total = CountItems(menu);
        Console.WriteLine("Кількість пунктів меню: " + total);
        Console.WriteLine("Кількість викликів countItems: " + callCount);
        Console.WriteLine();
        Console.WriteLine("Пошук пунктів:");
        Console.WriteLine("Зберегти: " + Find(menu, "Зберегти"));
        Console.WriteLine("Масштаб: " + Find(menu, "Масштаб"));
        Console.WriteLine("Довідка: " + Find(menu, "Довідка"));
        Console.WriteLine("Експорт: " + Find(menu, "Експорт"));
    }
}
