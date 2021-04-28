using System;

public class Statistics{
    
    public double Average{
        get{
            return Sum/Count;
        }
    }
    public double High;
    public double Low;
    public char Letter{
        get{
            switch(Average){
            case var d when d>=90.0:
            return 'A';

            case var d when d>=80.0:
            return 'B';

            case var d when d>=70.0:
            return 'C';

            default:
            return 'F';
        }
        }
    }
    public int Count;
    public double Sum;

    public void Add(double number){
        Sum+=number;
        Count+=1;
        Low=Math.Min(number, Low);
        High=Math.Max(number, High);
    }

    public Statistics(){
        Sum=0.0;
        Count=0;
        High=double.MinValue;
        Low=double.MaxValue;
    }

}