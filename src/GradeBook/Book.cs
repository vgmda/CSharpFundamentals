using System;
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

    public void AddLetterGrade(char letter)
    {
        switch(letter)
        {
            case 'A':
                AddGrade(90);
                break;

            case 'B':
                AddGrade(80);
                break;
            
            case 'C':
                AddGrade(70);
                break;

            case 'D':
                AddGrade(60);
                break;

            default:
                AddGrade(0);
                break;
        }
    }

    // Instance member (AddGrade) of a class book
    public void AddGrade(double grade) 
    {
        if (grade <= 100 || grade >= 0)
        {
            grades.Add(grade);
        }
        else
        {
            Console.WriteLine("Invalid value.");
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

        return result;
    }


}