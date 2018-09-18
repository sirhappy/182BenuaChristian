using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the Voltage: U, and Resistor's Resistance: R (In One Line)");
        int[] data = new int[2];
        try
        {
            data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine("The Wattage is: " + (double)data[0] * data[0] / data[1]);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Input was empty");
        }
        catch (System.FormatException)
        {
            Console.WriteLine("Something Wrong With Your Input");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Don't Let Your Resistance Be Zero");
        }
        Console.WriteLine("Press Enter to Exit");
        Console.ReadLine();

    }
}

