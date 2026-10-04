using System;
using System.Text;

class Student
{
    public string Surname { get; set; }
    public string Group { get; set; }
    public int Grade { get; set; }
    public int Year { get; set; }
    public Student(string surname, string group, int grade, int year)
    {
        Surname = surname;
        Group = group;
        Grade = grade;
        Year = year;
    }
}
class Program
{
    static void PrintAll(string title, IEnumerable<Student> items)
    {
        Console.WriteLine(title);
        foreach (var s in items)
        {
            Console.WriteLine(
                $"{s.Surname,-12} {s.Group,-8} {s.Grade,-5} {s.Year}"
            );
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;
        List<Student> students = new List<Student>
        {
            new Student("Ткаченко",  "ІПЗ-3/1", 85, 2024),
            new Student("Бондар",    "ІПЗ-3/2", 92, 2023),
            new Student("Іваненко",  "ІПЗ-3/1", 85, 2024),
            new Student("Коваль",    "ІПЗ-3/2", 78, 2024),
            new Student("Сидоренко", "ІПЗ-3/1", 85, 2023),
            new Student("Мельник",   "ІПЗ-3/2", 92, 2024),
            new Student("Гриценко",  "ІПЗ-3/1", 78, 2023),
            new Student("Дяченко",   "ІПЗ-3/2", 85, 2023)
        };

        var bySurname = students
            .OrderBy(s => s.Surname)
            .ToList();
        PrintAll("1. За прізвищем:", bySurname);

        var byGrade = students
            .OrderByDescending(s => s.Grade)
            .ToList();
        PrintAll("2. За балом:", byGrade);

        var byGroupAndGrade = students
            .OrderBy(s => s.Group)
            .ThenByDescending(s => s.Grade)
            .ToList();
        PrintAll("3. За групою та балом:", byGroupAndGrade);

        var byGradeAndSurname = students
            .OrderByDescending(s => s.Grade)
            .ThenBy(s => s.Surname)
            .ToList();
        PrintAll("4. За балом і прізвищем:", byGradeAndSurname);
    }
}