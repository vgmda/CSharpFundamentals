using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook;

public delegate void GradeAddedDelegate(object sender, EventArgs args);

public interface IBook
{
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
}

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

public abstract class Book : NamedObject, IBook
{
    protected Book(string name) : base(name)
    {
    }

    public abstract event GradeAddedDelegate GradeAdded;

    public abstract void AddGrade(double grade);

    public abstract Statistics GetStatistics();
}

public class InMemoryBook : Book
{
    public override event GradeAddedDelegate GradeAdded;
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

    public override Statistics GetStatistics()
    {
        var result = new Statistics();


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
            result.Add(grades[i]);
        }



        return result;
    }


}

public class DiskBook : Book
{
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
        using (var writer = File.AppendText($"{Name}.txt"))
        {
            writer.WriteLine(grade);
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }
    }

    public override Statistics GetStatistics()
    {
        var result = new Statistics();

        using (var reader = File.OpenText($"{Name}.txt"))
        {
            reader.ReadLine();
        }

        return result;
    }
}
