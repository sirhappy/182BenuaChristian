using System;


class Program
{
    static void Main(string[] args)
    {
        for (int a = 1; a <= 20; ++a)
        {
            for (int b = a; b <= 20; ++b)
            {
                for (int c = a + 1; c <= 20; ++c)
                {
                    if (a * a + b * b == c * c)
                    {
                        Console.WriteLine("a:{0}, b:{1}, c:{2}", a, b, c);
                    }
                }
            }
        }
    }
}

