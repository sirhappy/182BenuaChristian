using System;
using mylib;
namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int n;
                try
                {
                    n = int.Parse(Console.ReadLine());
                    MyString[] arr = new MyString[2];
                    arr[0] = new LatString(n, 'a', 'z');
                    arr[1] = new RusString(n, 'а', 'я');
                    Console.WriteLine(arr[0].Str);
                    Console.WriteLine(arr[1].Str);
                    Console.WriteLine(arr[0].IsPalindrome());
                    Console.WriteLine(arr[1].IsPalindrome());
                    Console.WriteLine(((RusString)(arr[1])).CountLetter('а'));
                    Console.WriteLine("enter size");
                    
                } catch (ArgumentOutOfRangeException ex) {
                    Console.WriteLine(ex.Message);
                    continue;
                } catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                Console.WriteLine("To exit press escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
