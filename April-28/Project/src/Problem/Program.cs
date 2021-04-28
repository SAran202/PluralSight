using System;

namespace Problem
{
    class Program
    {
        static void Main(string[] args)
        {
           IBook book=new DiskBook("My Grade");
           book.GradeAdded+=OnGradeAdded;

           EnterGrades(book);

           var stats=book.GetStatistics();

            Console.WriteLine($"Book Named {book.Name}");
            Console.WriteLine($"Average is {stats.Average:N1}");
            Console.WriteLine($"Higher is {stats.High:N1}");
            Console.WriteLine($"Lower is {stats.Low:N1}");
            Console.WriteLine($"Letter grade is {stats.Letter}");
            
        }

        private static void OnGradeAdded(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        private static void EnterGrades(IBook book){
            while(true){
                Console.WriteLine("Enter Grade r q: ");
                var input=Console.ReadLine();

                if(input=="q"){
                    break;
                }
                try{
                    var grade=double.Parse(input);
                    book.AddGrade(grade);
                }catch(ArgumentException e){
                    Console.WriteLine(e.Message);
                }catch(FormatException e){
                    Console.WriteLine(e.Message);
                }finally{
                    Console.WriteLine("**");
                }
            }

            var stats=book.GetStatistics();
            

            Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"Book Named {book.Name}");
            Console.WriteLine($"Average is {stats.Average:N1}");
            Console.WriteLine($"Higher is {stats.High:N1}");
            Console.WriteLine($"Lower is {stats.Low:N1}");
            Console.WriteLine($"Letter grade is {stats.Letter}");
        }
    }
}
