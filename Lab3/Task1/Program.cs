using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main()
    {
        List<string> journal = new List<string>();
        Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;
        journal.Add("Вхід у систему");
        journal.Add("Відкрито документ");
        journal.Add("Збережено зміни");
        journal.Add("Вихід");
        Console.WriteLine("Журнал у зворотному порядку:");
        for (int i = journal.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(journal[i]);
        }
    }
}