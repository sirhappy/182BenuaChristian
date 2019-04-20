using System;

namespace task7
{
    public class Money
    {
        public int Rubles { get; private set; }
        public int Kopeck { get; private set; }

        public Money(int rub, int kop)
        {
            this.Rubles = rub + (kop - 99) / 100;
            this.Kopeck = (kop % 100 + 100) % 100;
        }

        public Money(double kop)
        {
            this.Rubles = (int) (kop / 100);
            this.Kopeck = (int) Math.Round(kop - this.Rubles * 100);
            this.Rubles += (this.Kopeck) / 100;
            this.Kopeck %= 100;
        }

        public int FullCostInKopecks => this.Rubles * 100 + this.Kopeck;

        public Money(Money other)
        {
            this.Rubles = other.Rubles;
            this.Kopeck = other.Kopeck;
        }

        public Money TransferCost(double commision) //5% ~ 0.05
        {
            return this * (1 + commision);
        }

        public static Money operator *(Money lhs, double rhs)
        {
            return new Money(lhs.FullCostInKopecks * rhs);
        }

        public static Money operator /(Money lhs, double rhs)
        {
            if (Math.Abs(rhs) < 1e-9)
            {
                throw new DivideByZeroException();
            }

            return new Money(lhs.FullCostInKopecks / rhs);
        }

        public override string ToString()
        {
            return $"{this.Rubles}руб. {this.Kopeck}коп.";
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Money money = new Money(10, 15);
            Console.WriteLine(money.TransferCost(0.05));
            Console.WriteLine(money * 2);
            Console.WriteLine(money / 2);
        }
    }
}