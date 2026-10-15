using System;
using System.Collections.Generic;
using System.Text;
class Request
{
    public string Name { get; set; }
    public int Minutes { get; set; }
    public Request(string name, int minutes)
    {
        Name = name;
        Minutes = minutes;
    }
}
class Program
{
    static bool IsBalanced(string line)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char ch in line)
        {
            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == ']' || ch == '}')
            {
                if (stack.Count == 0)
                    return false;
                char open = stack.Pop();
                if ((ch == ')' && open != '(') ||
                    (ch == ']' && open != '[') ||
                    (ch == '}' && open != '{'))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
    static int ProcessQueue(List<Request> requests)
    {
        Queue<Request> queue = new Queue<Request>();
        foreach (Request request in requests)
        {
            queue.Enqueue(request);
        }
        int currentTime = 0;
        int order = 1;
        if (queue.Count == 0)
        {
            Console.WriteLine("Обробляти нічого: черга порожня.");
            return 0;
        }
        while (queue.Count > 0)
        {
            Request request = queue.Dequeue();
            int start = currentTime;
            int finish = start + request.Minutes;
            Console.WriteLine(
                $"{order}. {request.Name} з {start} до {finish} хв");
            currentTime = finish;
            order++;
        }
        Console.WriteLine(
            $"Оброблено заявок: {order - 1}, загальний час: {currentTime} хв");
        return currentTime;
    }
    static void Main()
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Задача 1:");
        List<string> lines = new List<string>
        {
            "",
            "a + b",
            "{[a] + (b)}",
            "([)]",
            "a)",
            "(a[b]",
            "f(x[1]) * {y + (z)}"
        };
        foreach (string line in lines)
        {
            string result = IsBalanced(line) ? "так" : "ні";
            Console.WriteLine($"{line} -> {result}");
        }
        Console.WriteLine();
        Console.WriteLine("Задача 2:");
        List<Request> requests = new List<Request>
        {
            new Request("Довідка про навчання", 4),
            new Request("Академічна відпустка", 7),
            new Request("Копія наказу", 2),
            new Request("Виписка з оцінками", 6),
            new Request("Перескладання", 9),
            new Request("Студентський квиток", 3)
        };
        ProcessQueue(requests);
    }
}