using System;
using System.Linq;
using System.Text;
class Program
{
    static int comparisons = 0;
    static int LinearSearch(int[] items, int target)
    {
        for (int i = 0; i < items.Length; i++)
        {
            comparisons++;
            if (items[i] == target)
                return i;
        }
        return -1;
    }
    static int BinarySearch(int[] items, int target)
    {
        int low = 0;
        int high = items.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            comparisons++;
            if (items[mid] == target)
                return mid;
            comparisons++;
            if (items[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }
    static void Report(string name, int[] items, int target)
    {
        comparisons = 0;
        int index;
        if (name == "linear")
            index = LinearSearch(items, target);
        else
            index = BinarySearch(items, target);
        Console.WriteLine($"{name,-8} {target,-3} індекс={index,-3} порівнянь={comparisons}");
    }
    static void Main()
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;
        int[] data = { 42, 8, 60, 19, 3, 55, 12, 31, 68, 24, 49, 37, 71, 5, 27 };
        int[] sortedData = data.OrderBy(x => x).ToArray();
        Report("linear", sortedData, 3);
        Report("binary", sortedData, 3);
        Report("linear", sortedData, 71);
        Report("binary", sortedData, 71);
        Report("linear", sortedData, 31);
        Report("binary", sortedData, 31);
        Report("linear", sortedData, 1);
        Report("binary", sortedData, 1);
        Report("linear", sortedData, 99);
        Report("binary", sortedData, 99);
        Report("linear", sortedData, 50);
        Report("binary", sortedData, 50);
        int[] one = { 42 };
        Report("linear", one, 42);
        Report("binary", one, 42);
        int[] empty = { };
        Report("linear", empty, 42);
        Report("binary", empty, 42);
        comparisons = 0;
        int result = BinarySearch(data, 55);
        Console.WriteLine($"\nБінарний пошук на невідсортованому масиві: індекс={result}, порівнянь={comparisons}");
    }
}