using System;
using System.Collections.Generic;


namespace GradeBook;

public delegate void GradeAddedDelegate(object sender, EventArgs args);

public class NamedObject
{
    public NamedObject(string name)
    {
        Name = name;
    }

    public string Name
    {
        get;
        set;
    }
}

public abstract class Book : NamedObject
{
    protected Book(string name) : base(name)
    {
    }

    public abstract void AddGrade(double grade);

}

public class InMemoryBook : Book
{
    public event GradeAddedDelegate GradeAdded;
    public List<double> grades;

    // Only assigned in the class constructor
    readonly string category = "Science";
    public const string TOPIC = "Other";

    // Explicit (implicit) constructor
    public InMemoryBook(string name) : base(name)
    {
        grades = new List<double>();
        Name = name;
    }

    public void AddGrade(char letter)
    {
        switch (letter)
        {
            case 'A':
                AddGrade(90.0);
                break;

            case 'B':
                AddGrade(80.0);
                break;

            case 'C':
                AddGrade(70.0);
                break;

            case 'D':
                AddGrade(60.0);
                break;

            default:
                AddGrade(0);
                break;
        }
    }

    // Instance member (AddGrade) of a class book
    public override void AddGrade(double grade)
    {
        if (grade <= 100 && grade >= 0)
        {
            grades.Add(grade);
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }
        else
        {
            throw new ArgumentException($"Invalid {nameof(grade)}");
        }

    }

    public Statistics GetStatistics()
    {
        var result = new Statistics();
        result.Average = 0.0;
        result.High = double.MinValue;
        result.Low = double.MaxValue;

        // foreach(double grade in grades)
        // {
        //     // if(grade > result.High)
        //     // {
        //     //     result.High = grade;
        //     // }
        //     result.High = System.Math.Max(grade, result.High);
        //     result.Low = System.Math.Min(grade, result.Low);
        //     result.Average += grade;
        // }

        for (var i = 0; i < grades.Count; i++)
        {
            result.High = System.Math.Max(grades[i], result.High);
            result.Low = System.Math.Min(grades[i], result.Low);
            result.Average += grades[i];
        }

        result.Average /= grades.Count;

        // Advanced switch statement
        switch (result.Average)
        {
            case var d when d >= 90.0:
                result.Letter = 'A';
                break;
            case var d when d >= 80.0:
                result.Letter = 'B';
                break;
            case var d when d >= 70.0:
                result.Letter = 'C';
                break;
            case var d when d >= 60.0:
                result.Letter = 'D';
                break;

            default:
                result.Letter = 'F';
                break;
        }

        return result;
    }


}