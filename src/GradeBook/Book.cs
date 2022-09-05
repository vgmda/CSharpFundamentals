using System.Collections.Generic;


namespace GradeBook;

public class Book 
{
    public List<double> grades;
    public string Name;

    // Explicit (implicit) constructor
    public Book(string name)
    {
        grades = new List<double>();
        Name = name;

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
            // if(grade > result.High)
            // {
            //     result.High = grade;
            // }
            result.High = System.Math.Max(grade, result.High);
            result.Low = System.Math.Min(grade, result.Low);
            result.Average += grade;
        }
        result.Average /= grades.Count;

        return result;
    }


}