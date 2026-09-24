using System;
using System.Text;
class Program
{
    static void Main()
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;
        int[] months = { 1, 1, 2, 5, 5, 12 };
        int[] sums = { 100, 50, 200, 300, 150, 400 };
        int[] total = new int[12];
        for (int i = 0; i < months.Length; i++)
        {
            total[months[i] - 1] += sums[i];
        }
        Console.WriteLine("Підсумки за місяцями:");
        for (int i = 0; i < 12; i++)
        {
            Console.WriteLine($"Місяць {i + 1}: {total[i]}");
        }
    }
}