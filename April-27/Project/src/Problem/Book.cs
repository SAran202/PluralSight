using System;
using System.Collections.Generic;

public class Book{
    public Book(string name){
        grades=new List<double>();
        this.name=name;
    }
    public void AddGrade(double grade){
        if(grade<=100 && grade>=0){
            grades.Add(grade);
        }else{
            throw new ArgumentException("Invalid {nameof(grade)}");
        }
    }
    public Statistics GetStatistics(){
        var result =new Statistics();
        result.Average=0.0;
        result.High=double.MinValue;
        result.Low=double.MaxValue;

        foreach(var grade in grades){
            result.Low=Math.Min(grade,result.Low);
            result.High=Math.Max(grade,result.High);
            result.Average +=grade;
        }
        result.Average/=grades.Count;

        switch(result.Average){
            case var d when d>=90.0:
            result.Letter='A';
            break;

            case var d when d>=80.0:
            result.Letter='B';
            break;

            case var d when d>=70.0:
            result.Letter='C';
            break;

            default:
            result.Letter='F';
            break;
        }
        return result;
    }
    private List<double> grades;
    private string name;
}