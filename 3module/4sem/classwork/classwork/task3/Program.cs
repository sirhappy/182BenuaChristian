using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace task3
{

    public class Bead
    {

        public event Action<double> OnBeadRadiusChanged;

        double _radius;

        public double Radius
        {
            get => _radius;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Radius), "Radius of a bead cant be a negative");
                }
                _radius = value;
                OnBeadRadiusChanged?.Invoke(value);
            }
        }

        public Bead()
        {
            this.Radius = 1;
        }

        public Bead(double rad)
        {
            this.Radius = rad;
        }

        public void RecalcRadius(double len) 
        {
            Radius = len;
        }

        public override string ToString()
        {
            return $"Bead: Radius : {Radius.ToString("F2")}";
        }
    }

    public class BeadChain
    {
        double _length;
        List<Bead> beads;

        int _beadsCount;

        public event Action<double> ChainLengthChangedEvent;
        public event Action<double> BeadsCountChanged;

        public int Count
        {
            get => _beadsCount;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(_beadsCount), "Amount of beads cant be negative or zero");
                }
                _beadsCount = value;
                //AdjustBeads();
                BeadsCountChanged?.Invoke(Length / _beadsCount / 2);
            }
        }

        private void AdjustBeads(double newLen)
        {
            double totalLength = beads.Sum((arg) => arg.Radius * 2);

            double numberOfBeadsToAdd = ((Length - totalLength) / newLen / 2);

            if (numberOfBeadsToAdd > 0)
            {
                for (int i = 0; i < (int)numberOfBeadsToAdd; ++i)
                {
                    Bead bead = new Bead(newLen);
                    this.BeadsCountChanged += bead.RecalcRadius;
                    this.ChainLengthChangedEvent += bead.RecalcRadius;
                    bead.OnBeadRadiusChanged += this.AdjustBeads;
                    this.beads.Add(bead);
                }
            } 
            else if (numberOfBeadsToAdd < 0)
            {
                Bead beadToDelete = beads.Find((arg) => Math.Abs(arg.Radius - newLen) < 1e-7);
                this.BeadsCountChanged -= beadToDelete.RecalcRadius;
                this.ChainLengthChangedEvent -= beadToDelete.RecalcRadius;
                beadToDelete.OnBeadRadiusChanged -= this.AdjustBeads;
                beads.Remove(beadToDelete);
            }


            /*if (Count <= beads.Count)
            {
                for (int i = 0; i < beads.Count - Count; ++i)
                {
                    this.BeadsCountChanged -= beads[0].RecalcRadius;
                    this.ChainLengthChangedEvent -= beads[0].RecalcRadius;
                    beads.RemoveAt(0);
                }
            }
            else
            {
                for (int i = 0; i < Count - beads.Count; ++i)
                {
                    Bead bead = new Bead();
                    this.BeadsCountChanged += bead.RecalcRadius;
                    this.ChainLengthChangedEvent += bead.RecalcRadius;
                    beads.Add(bead);
                }
            }*/



        }

        public double Length
        {
            get => _length;

            set
            {
                _length = value;
                ChainLengthChangedEvent?.Invoke(_length / beads.Count / 2);
            }
        }

        public BeadChain(double len, int beadsCount)
        {
            Length = len;
            beads = new List<Bead>();
            CreateBeads(beadsCount);
        }

        private void CreateBeads(int beadsCount)
        {
            double allowedLength = Length / beadsCount / 2;

            for (int i = 0; i < beadsCount; ++i)
            {
                Bead bead = new Bead(allowedLength);
                this.BeadsCountChanged += bead.RecalcRadius;
                this.ChainLengthChangedEvent += bead.RecalcRadius;
                bead.OnBeadRadiusChanged += this.AdjustBeads;
                beads.Add(bead);
            }
        }

        public override string ToString()
        {
            string ans = "Beads:\n";
            foreach (var el in beads)
            {
                ans += el.ToString() + "\n";
            }
            return ans;
        }

    }

    class Program
    {

        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T : struct
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public,
             null, new[] { typeof(string), typeof(T).MakeByRefType() }, null);
            while (!((bool)(methodInfo.Invoke(null, (parameters = new object[]
            { Console.ReadLine(), null }))) && valid((T)parameters[1])))
            {
                Console.WriteLine(Out);
            }
            return (T)parameters[1];
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1) Change Chain Length\n2) Change Number of beads on Chain\n3) Exit");
        }

        static void Main(string[] args)
        {
            int choice = 0;
            BeadChain chain = null;

            do
            {
                if (choice == 0)
                {
                    double chainLen = Read<double>("Enter length of chain",
                    "smth wrong with chain length, reenter pls", (arg) => arg > 0 && arg < 10000);

                    int numberOfBeads = Read<int>("enter Number of beads", "Smth wrong, reenter pls", (arg) => arg > 0 && arg < 1000);
                    chain = new BeadChain(chainLen, numberOfBeads);

                    Console.WriteLine(chain);
                }

                PrintMenu();

                choice = Read<int>("", "Smth wrong with your choice, reenter pls", (arg) => arg >= 1 && arg <= 3);

                if (choice == 1)
                {
                    double newLen = Read<double>("Enter new chail length", "smth wrong, reenter pls", (arg) => arg > 0 && arg < 10000);
                    chain.Length = newLen;
                }
                else if (choice == 2)
                {
                    int newBeadsCount = Read<int>("enter Number of beads", "Smth wrong, reenter pls", (arg) => arg > 0 && arg < 1000);
                    chain.Count = newBeadsCount;
                }

                if (choice != 3)
                {
                    Console.WriteLine(chain);
                }


            } while (choice != 3);
        }
    }
}
