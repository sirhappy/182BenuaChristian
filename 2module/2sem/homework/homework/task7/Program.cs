using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    class myFunction
    {
        private double xMin;
        private double xMax;

        public myFunction()
        {
            xMin = xMax = 0;
        }

        public myFunction(double mn, double mx)
        {
            xMin = mn;
            xMax = mx;
        }

        public double this[double index]
        {
            get
            {
                if (index < xMin || index > xMax)
                {
                    return 0;
                }
                else
                {
                    return Math.Sin(index);
                }
            }
        }
    }


    class Program
    {
        static void Main()
        {
            myFunction obj = new myFunction(0, Math.PI);
            double dx = 1e-6;
            double ans = 0;
            for (double curr = dx; curr <= Math.PI; curr += dx)
            {
                ans += dx * (obj[curr] + obj[curr - dx]) / 2;
            }
            Console.WriteLine(ans);
            Console.WriteLine(-Math.Cos(Math.PI) + Math.Cos(0));
            Console.ReadLine();
        }
    }
}
