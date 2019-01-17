using System;

namespace classWork
{

    delegate int Cast(double a);

    class Program
    {
    

        static void Main(string[] args)
        {
            Cast func = (x) => (int)(Math.Log10(x));
            Cast func2 = (x) => {
                int convA = (int)x;
                int left = convA - convA % 2;
                int right = convA + convA % 2;

                if (Math.Abs(x - left) < Math.Abs(x - right))
                {
                    return left;
                }
                return right;
            };

            Cast container;

            Console.WriteLine(func2(5.5));
            Console.WriteLine(func2(4.5));

            Console.WriteLine(func(10));
            Console.WriteLine(func(20));
            Console.WriteLine(func(100));


            container = func;
            container += func2;

            Console.WriteLine(container(1));
        }
    }
}
