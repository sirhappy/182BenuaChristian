using System;


class Program
{

    public static bool Shift(ref char ch) {
        if (!(ch >= 'a' && ch <= 'z')) {
            return false;
        }
        ch = (char)((ch - 'a' + 4) % 26 + 'a');
        return true;
    }

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.WriteLine("Enter char value");
            char ch;
            string str;
            while ((str = Console.ReadLine()).Length > 1) {
                Console.WriteLine("Smth wrong with input, reenter char");
            }
            ch = str[0];
            

            if (Shift(ref ch)) {
                Console.WriteLine(ch);
            } else {
                Console.WriteLine("Wrong char value");
            }
            Console.WriteLine("To exit press escape");
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

