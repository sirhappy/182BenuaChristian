using System;
using System.Collections.Generic;
using System.Reflection;

namespace task4
{
    public class Reader
    {
        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T : struct
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public,
                null, new[] {typeof(string), typeof(T).MakeByRefType()}, null);
            while (!((bool) (methodInfo.Invoke(null, (parameters = new object[]
                         {Console.ReadLine(), null}))) && valid((T) parameters[1])))
            {
                Console.WriteLine(Out);
            }

            return (T) parameters[1];
        }
    }

    public static class RandomContainer
    {
        private static Random random = new Random();

        public static int NextInt(int from, int to)
        {
            return random.Next(from, to + 1);
        }
    }

    public class AtomsGrid
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public int Z { get; private set; }

        public AtomsGrid(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            _atomsSet = new HashSet<Atom>();
        }

        private HashSet<Atom> _atomsSet;

        public AtomsGrid(IEnumerable<Atom> enumerable)
        {
            this._atomsSet = new HashSet<Atom>(enumerable);
        }

        public bool AddToSet(Atom atom)
        {
            return _atomsSet.Add(atom);
        }

        public bool Contains(Atom atom)
        {
            return _atomsSet.Contains(atom);
        }

        public static AtomsGrid ReadGrid()
        {
            int x = Reader.Read<int>("Enter Xmax coord of grid", "Smth wrong, reenter pls",
                (el) => el >= 0 && el <= 100);
            int y = Reader.Read<int>("Enter Ymax coord of grid", "Smth wrong, reenter pls",
                (el) => el >= 0 && el <= 100);
            int z = Reader.Read<int>("Enter Zmax coord of grid", "Smth wrong, reenter pls",
                (el) => el >= 0 && el <= 100);
            return new AtomsGrid(x, y, z);
        }
    }

    public class Atom : IEquatable<Atom>
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public int Tries { get; private set; }

        public Atom(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            Tries = 0;
        }

        public void GenerateNewCoords(AtomsGrid grid)
        {
            this.X = RandomContainer.NextInt(0, grid.X);
            this.Y = RandomContainer.NextInt(0, grid.Y);
            this.Z = RandomContainer.NextInt(0, grid.Z);
            Console.WriteLine($"New generated Coords: {X}, {Y}, {Z} and tries: {Tries}");
            this.Tries++;
        }

        public bool Equals(Atom obj)
        {
            if (obj is null)
            {
                return false;
            }

            return this.X == obj.X && this.Y == obj.Y && this.Z == obj.Z;
        }

        public static Atom GenerateAtom(AtomsGrid grid)
        {
            Atom atom = new Atom(-1, -1, -1);
            do
            {
                atom.GenerateNewCoords(grid);
            } while (!grid.AddToSet(atom));

            return atom;
        }

        public override int GetHashCode()
        {
            return (X, Y, Z).GetHashCode();
        }

        public static bool operator ==(Atom lhs, Atom rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Atom lhs, Atom rhs)
        {
            return !lhs.Equals(rhs);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var grid = AtomsGrid.ReadGrid();
            int n = Reader.Read<int>("Enter amount of atoms to be placed inside Grid", "Smth wrong, reenter pls",
                (el) => el > 0 && el <= (grid.X + 1) * (grid.Y + 1) * (grid.Z + 1));
            for (int i = 0; i < n; ++i)
            {
                Atom atom = Atom.GenerateAtom(grid);
                Console.WriteLine($"\n\n Tries: {atom.Tries} \n");
            }
        }
    }
}