using System;


class Program
{
    static void Main(string[] args)
    {
        int Code;
        Console.WriteLine("Enter ASCII code between 32 and 127 inclusive");
        if (int.TryParse(Console.ReadLine(), out Code))
        {
            Console.WriteLine((char)Code);
        }
        else
        {
            Console.WriteLine("Something Wrong With Your Input");
        }
        Console.WriteLine("Press Enter to Exit");
        Console.ReadLine();
    }
}

