using System;
using System.Collections.Generic;
using System.Linq;
record Client(int Id, string Name);
record Order(int Number, int ClientId, int Sum);
class Program
{
    static void Main()
    {
        var clients = new List<Client>
        {
            new(101, "Коваленко"),
            new(102, "Мельник"),
            new(103, "Шевчук"),
            new(104, "Бондар"),
            new(105, "Ткачук"),
            new(106, "Гриценко")
        };
        var orders = new List<Order>
        {
            new(1, 103, 450), new(2, 101, 120),
            new(3, 105, 980), new(4, 103, 300),
            new(5, 102, 75),  new(6, 106, 1500),
            new(7, 101, 220), new(8, 103, 60)
        };
        var blocked = new List<int> { 102, 104 };
        /*
        foreach (var order in orders)
            foreach (var client in clients)
                if (client.Id == order.ClientId)
                    Console.WriteLine(
                        $"Замовлення {order.Number} — {client.Name}");
        */
        var clientsById = clients.ToDictionary(c => c.Id);
        foreach (var order in orders)
        {
            if (clientsById.TryGetValue(order.ClientId, out var client))
                Console.WriteLine(
                    $"Замовлення {order.Number} — {client.Name}");
        }
        /*
        int total = 0;
        foreach (var order in orders)
            if (!blocked.Contains(order.ClientId))
                total += order.Sum;
        Console.WriteLine($"Сума прийнятих замовлень: {total}");
        */
        var blockedIds = new HashSet<int>(blocked);
        int total = 0;
        foreach (var order in orders)
        {
            if (!blockedIds.Contains(order.ClientId))
                total += order.Sum;
        }
        Console.WriteLine($"Сума прийнятих замовлень: {total}");
        /*
        var counted = new List<int>();
        foreach (var order in orders)
        {
            if (counted.Contains(order.ClientId))
                continue;
            int count = 0;
            foreach (var other in orders)
                if (other.ClientId == order.ClientId)
                    count++;
            counted.Add(order.ClientId);
            Console.WriteLine($"{order.ClientId}: {count}");
        }
        */
        var orderCounts = new Dictionary<int, int>();
        foreach (var order in orders)
        {
            if (orderCounts.ContainsKey(order.ClientId))
                orderCounts[order.ClientId]++;
            else
                orderCounts[order.ClientId] = 1;
        }
        var printed = new HashSet<int>();
        foreach (var order in orders)
        {
            if (printed.Add(order.ClientId))
            {
                Console.WriteLine(
                    $"{order.ClientId}: {orderCounts[order.ClientId]}");
            }
        }
        var best = orders[0];
        foreach (var order in orders)
        {
            if (order.Sum > best.Sum)
                best = order;
        }
        Console.WriteLine($"Найбільше замовлення: {best.Sum}");
        /*
        foreach (var order in orders)
        {
            var byId = new Dictionary<int, Client>();
            foreach (var client in clients)
                byId[client.Id] = client;

            Console.WriteLine(
                $"Замовлення {order.Number} — " +
                $"{byId[order.ClientId].Name}");
        }
        */
        var byId = clients.ToDictionary(c => c.Id);
        foreach (var order in orders)
        {
            Console.WriteLine(
                $"Замовлення {order.Number} — " +
                $"{byId[order.ClientId].Name}");
        }
    }
}