using System;

namespace Problem
{
    public class Program
    {
        static void Main(string[] args)
        {
           var book=new Book("My Grade");
            
            while(true){
                Console.WriteLine("Enter Grade r q: ");
                var input=Console.ReadLine();

                if(input=="q"){
                    break;
                }
                try{
                    var grade=double.Parse(input);
                    book.AddGrade(grade);
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }

            var stats=book.GetStatistics();

            Console.WriteLine("Average is {stats.Average:N1}");
            Console.WriteLine("Higher is {stats.High:N1}");
            Console.WriteLine("Lower is {stats.Low:N1}");
            Console.WriteLine("Letter grade is {stats.Letter}");
        }
    }
}
