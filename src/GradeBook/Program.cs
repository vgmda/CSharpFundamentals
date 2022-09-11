using System;
namespace GradeBook;



public class Program
{
    static void Main(string[] args)
    {
        var book = new Book("Grade Book");
        book.GradeAdded += OnGradeAdded;

        // book.AddGrade(4.1);
        // book.AddGrade(12.7);
        // book.AddGrade(55.2);
        // book.AddGrade(81.9);
        // book.grades.Add(95.3);


        EnterGrades(book);

        var stats = book.GetStatistics();

        Console.WriteLine($"For the book name {book.Name}");
        Console.WriteLine($"The lowest grade is {stats.Low}");
        Console.WriteLine($"The highest grade is {stats.High}");
        Console.WriteLine($"The average grade is {stats.Average:N1}");
        Console.WriteLine($"The letter grade is {stats.Letter}");


        // Explicit typing
        // var grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
        // grades.Add(56.1);

    }

    private static void EnterGrades(Book book)
    {
        while (true)
        {
            Console.WriteLine("Enter a grade or 'q' to quit.");
            var input = Console.ReadLine();

            if (input == "q")
            {
                break;
            }

            try
            {
                // Check if the input is not null
                // if (!string.IsNullOrEmpty(input))
                // {
                //     var grade = double.Parse(input);
                //     book.AddGrade(grade);
                // }
                var grade = double.Parse(input);
                book.AddGrade(grade);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("*****");
            }

        }
    }

    static void OnGradeAdded(object sender, EventArgs e)
    {
        Console.WriteLine("A grade was added");
    }
}