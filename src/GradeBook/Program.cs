namespace GradeBook;

public class Program
{
    static void Main(string[] args)
    {
        var book = new Book("Grade Book");
        book.AddGrade(4.1);
        book.AddGrade(12.7);
        book.AddGrade(55.2);
        book.AddGrade(81.9);
        book.grades.Add(95.3);

        var stats = book.GetStatistics();

        System.Console.WriteLine($"The lowest grade is {stats.Low}");
        System.Console.WriteLine($"The highest grade is {stats.High}");
        System.Console.WriteLine($"The average grade is {stats.Average:N1}");


        // Explicit typing
        // var grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
        // grades.Add(56.1);

    }
}