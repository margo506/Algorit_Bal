using System;
using System.Text;
class Program
{
    static void Main()
    {
        int N = 5;
        string[] eventsArray = new string[N];
        int writeIndex = 0;
        int count = 0;
        string[] stream =
        {
            "Подія1",
            "Подія2",
            "Подія3",
            "Подія4",
            "Подія5",
            "Подія6",
            "Подія7"
        };
        foreach (string e in stream)
        {
            eventsArray[writeIndex] = e;
            writeIndex = (writeIndex + 1) % N;
            if (count < N)
                count++;
        }
        Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Останні події:");
        int start = (count == N) ? writeIndex : 0;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(eventsArray[(start + i) % N]);
        }
    }
}
