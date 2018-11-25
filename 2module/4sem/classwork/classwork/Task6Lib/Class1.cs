using System;

namespace Task6Lib
{
    public abstract class Fxdx
    {
        public double From {
            get;
            protected set;
        }

        public double To {
            get; protected set;
        }

        public abstract double Fx(double arg);

        public static double Integral(Fxdx obj,double dx) {
            double ans = 0;
            for (double st = obj.From; st <= obj.To; st += dx) {
                ans += obj.Fx(st) + obj.Fx(st + dx);
            }
            ans *= dx;
            ans /= 2;
            return ans;
        }

        public static double Integral(Fxdx obj, int pieces)
        {
            double dx = (-obj.From + obj.To) / pieces;
            return Integral(obj, dx);
        }

        public static double IntegralRect(Fxdx obj, double dx) {
            double ans = 0;
            for (double st = obj.From; st <= obj.To; st += dx)
            {
                ans += obj.Fx(st);
            }
            ans *= dx;
            return ans;
        }

        public static double IntegralRect(Fxdx obj, int pieces) {
            return IntegralRect(obj, ((-obj.From + obj.To) / pieces));
        }

        public Fxdx() {
            From = To = 0;
        }

        public Fxdx(double fr, double to) {
            From = fr;
            To = to;
        }
    }

    public class Func1 : Fxdx {
        public override double Fx(double arg) {
            return arg / (arg * arg + 1) / (arg * arg + 1);
        }

        public Func1() {}

        public Func1(double fr, double to) : base(fr, to) {}
    }

    public class Func2 : Fxdx {
        public Func2(){}

        public Func2(double fr, double to) : base(fr, to){}

        public override double Fx(double arg)
        {
            return 2 * Math.Sin(2 * arg);
        }

    }

    public class Func3 : Fxdx {
        public Func3(){}

        public Func3(double st, double fin) : base(st, fin) { }

        public override double Fx(double arg)
        {
            return Math.Cos(arg * arg * arg);
        }
    }
    

}
