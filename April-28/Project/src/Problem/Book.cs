using System;
using System.Collections.Generic;
using System.IO;

namespace Problem{
public delegate void GradeAddedDelegate(object sender,EventArgs args);

public class Namedobject{

    public Namedobject(string name){
        Name=name;
    }
    public string Name{
        get;set;
    }
}

public interface IBook{
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name{get;}
    event GradeAddedDelegate GradeAdded;
}
public abstract class Book:Namedobject,IBook{

    public Book(string name):base(name){

    }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook:Book{
        public DiskBook(string name):base(name){

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            var writer = File.AppendText($"{Name}.txt");
            writer.WriteLine(grade);
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
public class InMemoryBook:Book{
    public InMemoryBook(string name):base(name){

        grades=new List<double>();
        Name = name;
    }
    public void AddGrade(char letter){
        switch(letter){
            case 'A':
            AddGrade(90);
            break;

            case 'B':
            AddGrade(80);
            break;

            case 'C':
            AddGrade(70);
            break;

            default:
            AddGrade(0);
            break;
        }
    }
    public override void AddGrade(double grade){
        if(grade<=100 && grade>=0){
            grades.Add(grade);
        }else{
            throw new ArgumentException($"Invalid {nameof(grade)}");
        }
    }

    public override event GradeAddedDelegate GradeAdded;
    public override Statistics GetStatistics(){
        var result =new Statistics();
        
        for(var index = 0; index < grades.Count;index+=1){
            result.Add(grades[index]);
        }
        return result;
    }
    private List<double> grades;

    public const string CATEGORY="Science";
}
}