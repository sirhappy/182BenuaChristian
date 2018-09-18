using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Lengths Of Two Cathetuses(In One Line)");
        try
        {
            var data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Console.WriteLine("Hypotenuse is : " + Math.Sqrt(data[0] * data[0] + data[1] * data[1]));
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Input was empty");
        }
        catch (System.FormatException)
        {
            Console.WriteLine("Something Wrong With Your Input");
        }
        Console.WriteLine("Press Enter to Exit");
        Console.ReadLine();
    }
}

