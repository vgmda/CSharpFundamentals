namespace GradeBook;

class Book 
{
    public List<double> grades;
    private string name;

    // Explicit (implicit) constructor
    public Book(string name)
    {
        grades = new List<double>();
        this.name = name;

    }

    // Instance member (AddGrade) of a class book
    public void AddGrade(double grade) 
    {
        grades.Add(grade);
    }

    public Statistics GetStatistics()
    {
        var result = new Statistics();
        result.Average = 0.0;
        result.High = double.MinValue;
        result.Low = double.MaxValue;

        foreach(double grade in grades)
        {
            // if(number > highGrade)
            // {
            //     highGrade = number;
            // }
            result.High = Math.Max(grade, result.High);
            result.Low = Math.Min(grade, result.Low);
            result.Average += grade;
        }
        result.Average /= grades.Count;

        return result;
    }

    Console.WriteLine($"The lowest grade is {lowGrade}");
        Console.WriteLine($"The highest grade is {highGrade}");
        Console.WriteLine($"The average grade is {result:N1}");



}