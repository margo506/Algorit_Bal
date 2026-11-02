using System;
using System.Collections.Generic;
class Request
{
    public string Name;
    public int Priority;
    public int Seq;
    public Request(string name, int priority, int seq)
    {
        Name = name;
        Priority = priority;
        Seq = seq;
    }
}
class Program
{
    static Request[] incoming =
    {
        new Request("Оновити підпис у листі", 3, 1),
        new Request("Сервер не відповідає", 1, 2),
        new Request("Не друкує принтер", 2, 3),
        new Request("Не працює термінал оплати", 1, 4),
        new Request("Змінити шпалери", 3, 5)
    };
    static Request late =
        new Request("Відвалився інтернет у відділі", 1, 6);
    static void PrintRequest(int number, Request request)
    {
        Console.WriteLine(
            $"{number}. {request.Name} Пріоритет: {request.Priority} Seq: {request.Seq}");
    }
    static void ProcessAll(Request[] incoming)
    {
        Console.WriteLine("");
        PriorityQueue<Request, int> queue = new();
        foreach (Request request in incoming)
        {
            queue.Enqueue(request, request.Priority);
        }
        int number = 1;
        while (queue.Count > 0)
        {
            Request request = queue.Dequeue();
            PrintRequest(number, request);
            number++;
        }
    }
    static void ProcessStable(Request[] incoming)
    {
        Console.WriteLine("");
        PriorityQueue<Request, (int, int)> queue = new();
        foreach (Request request in incoming)
        {
            queue.Enqueue(request, (request.Priority, request.Seq));
        }
        int number = 1;
        while (queue.Count > 0)
        {
            Request request = queue.Dequeue();
            PrintRequest(number, request);
            number++;
        }
    }
    static void ProcessWithLate(Request[] incoming, Request late)
    {
        Console.WriteLine("");
        PriorityQueue<Request, (int, int)> queue = new();
        foreach (Request request in incoming)
        {
            queue.Enqueue(request, (request.Priority, request.Seq));
        }
        for (int i = 1; i <= 2; i++)
        {
            Request request = queue.Dequeue();
            PrintRequest(i, request);
        }
        queue.Enqueue(late, (late.Priority, late.Seq));
        int number = 3;
        while (queue.Count > 0)
        {
            Request request = queue.Dequeue();
            PrintRequest(number, request);
            number++;
        }
    }
    static void Main()
    {
        ProcessAll(incoming);
        ProcessStable(incoming);
        ProcessWithLate(incoming, late);
    }
}