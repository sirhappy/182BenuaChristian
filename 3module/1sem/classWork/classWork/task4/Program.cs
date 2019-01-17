using System;
using System.Collections.Generic;
using System.Reflection;

namespace task4
{
    /// <summary>
    /// Pair of two values
    /// </summary>
    public class Pair<T, V> where T : struct, IEquatable<T> where V : struct, IEquatable<V> {

        /// <summary>
        /// Gets the first value in pair
        /// </summary>
        /// <value>The first value in pair</value>
        public T first { get; private set; }

        /// <summary>
        /// Gets the second value in Pair
        /// </summary>
        /// <value>The second value in Pair</value>
        public V second { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:task4.Pair`2"/> class.
        /// </summary>
        /// <param name="fir">First value in pair</param>
        /// <param name="sec">Second value in pair</param>
        public Pair(T fir, V sec) {
            first = fir;
            second = sec;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="task4.Pair<T, V>"/> is equal to another specified <see cref="task4.Pair<T, V>"/>.
        /// </summary>
        /// <param name="a">The first <see cref="task4.Pair<T, V>"/> to compare.</param>
        /// <param name="b">The second <see cref="task4.Pair<T, V>"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Pair<T, V> a, Pair<T, V> b)
        {
            return a.first.Equals(b.first) && a.second.Equals(b.second);
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="task4.Pair<T, V>"/> is not equal to another specified <see cref="task4.Pair<T, V>"/>.
        /// </summary>
        /// <param name="a">The first <see cref="task4.Pair<T, V>"/> to compare.</param>
        /// <param name="b">The second <see cref="task4.Pair<T, V>"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Pair<T, V> a, Pair<T, V> b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:task4.Pair`2"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:task4.Pair`2"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:task4.Pair`2"/>;
        /// otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            Pair<T, V> other = (Pair<T, V>)(obj);
            return other == this;
        }

        /// <summary>
        /// Combines the hash codes.
        /// </summary>
        /// <returns>New cpmbined hash code </returns>
        /// <param name="h1">first hash code</param>
        /// <param name="h2">second hash code</param>
        internal static int CombineHashCodes(int h1, int h2)
        {
            return (((h1 << 5) + h1) ^ h2);
        }
        /// <summary>
        /// Serves as a hash function for a <see cref="T:task4.Pair`2"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return CombineHashCodes(first.GetHashCode(), second.GetHashCode());
        }
    }

    /// <summary>
    /// Robot.
    /// </summary>
    public class Robot {

        /// <summary>
        /// The x coord
        /// </summary>
        int _x;

        /// <summary>
        /// The y coord
        /// </summary>
        int _y;

        /// <summary>
        /// Gets the x coord
        /// </summary>
        /// <value>The x coord</value>
        /// 
        public int X
        { 
            get => _x; 
            private set 
            {
                _x = value;
                Path.Add(new Pair<int, int>(_x, _y));
            } 
        }

        /// <summary>
        /// Gets the y coord
        /// </summary>
        /// <value>The y coord</value>
        public int Y {
            get => _y;

            private set {
                _y = value;
                Path.Add(new Pair<int, int>(_x, _y));
            }
        }

        /// <summary>
        /// Gets the robot's path.
        /// </summary>
        /// <value>The path array</value>
        public List<Pair<int, int>> Path {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:task4.Robot"/> class.
        /// </summary>
        public Robot() {
            Path = new List<Pair<int, int>>();
            Path.Add(new Pair<int, int>(0, 0));

        }


        /// <summary>
        /// Moves robot to the right
        /// </summary>
        public void R() {
            X++;
        }

        /// <summary>
        /// Moves robot to the left
        /// </summary>
        public void L() {
            X--;
        }

        /// <summary>
        /// Moves robot forward
        /// </summary>
        public void F() {
            Y--;
        }

        /// <summary>
        /// Moves robot backward
        /// </summary>
        public void B() {
            Y++;
        }
    }

    /// <summary>
    /// Field, where robot walks
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Gets the number of rows.
        /// </summary>
        /// <value>The rows amount</value>
        public int Rows { get; private set; }

        /// <summary>
        /// Gets the number of columns.
        /// </summary>
        /// <value>The columns.</value>
        public int Columns { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:task4.Field"/> class.
        /// </summary>
        public Field()
        {
            charColor['|'] = ConsoleColor.White;
            charColor['+'] = ConsoleColor.DarkGray;
            charColor['*'] = ConsoleColor.Red;
            charColor[' '] = ConsoleColor.White;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:task4.Field"/> class.
        /// </summary>
        /// <param name="rows">number of Rows.</param>
        /// <param name="cols">number of Cols.</param>
        public Field(int rows, int cols) : this()
        {
            Rows = rows;
            Columns = cols;
        }

        /// <summary>
        /// The color for the char in the console.
        /// </summary>
        public readonly Dictionary<char, ConsoleColor> charColor = new Dictionary<char, ConsoleColor>();

        /// <summary>
        /// The default color of the console symbols.
        /// </summary>
        public readonly ConsoleColor defaultConsoleColor = ConsoleColor.White;

        /// <summary>
        /// Gets the relative zero x coordinate
        /// </summary>
        /// <value>The zero x coord</value>
        public int ZeroX => Columns / 2;

        /// <summary>
        /// Gets the relative zero y coord.
        /// </summary>
        /// <value>The zero y coord.</value>
        public int ZeroY => Rows / 2;


        /// <summary>
        /// Prints the row
        /// </summary>
        public void PrintRow()
        {
            for (int i = 0; i < 2 * Columns + 1; ++i)
            {
                Console.Write("_");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        /// <summary>
        /// delegate for Move methods.
        /// </summary>
        delegate void Move();

        /// <summary>
        /// Prints the field.
        /// </summary>
        /// <param name="robot">Robot that will walk on this field</param>
        /// <param name="field">Field where robot gonna walk</param>
        public static void PrintField(Robot robot, Field field) {

            for (int i = 0; i < field.Rows; ++i) {
                field.PrintRow();
                Console.Write("|");
                for (int j = 0; j < field.Columns; ++j) {
                    char ans = ' ';
                    if (robot.Y == i - field.ZeroY && robot.X == j - field.ZeroX)
                    {
                        ans = '*';
                    }
                    else if (robot.Path.Contains(new Pair<int, int>(j - field.ZeroX, i - field.ZeroY))) {
                        ans = '+';
                    }
                    Console.ForegroundColor = field.charColor[ans];
                    Console.Write(ans);

                    Console.ForegroundColor = field.defaultConsoleColor;
                    Console.Write("|");
                }
                Console.WriteLine();
            }

            foreach (var pair in robot.Path) {
                if ((pair.first + field.ZeroX < 0 || pair.first + field.ZeroX >= field.Columns)
                    || (pair.second + field.ZeroY < 0 || pair.second + field.ZeroY >= field.Rows)) {
                    Console.WriteLine("Robot gone out of field bounds");
                    break;
                }
            }
        }


        /// <summary>
        /// Read value from console.
        /// </summary>
        /// <returns>The read value</returns>
        /// <param name="In">message before entering value</param>
        /// <param name="Out">error message.</param>
        /// <param name="valid">Validate function</param>
        /// <typeparam name="T">The type of value, that will be read</typeparam>
        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T:struct
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(T).MakeByRefType() }, null);
            while (!((bool)(methodInfo.Invoke(null, (parameters = new object[] { Console.ReadLine(), null }))) && valid((T)parameters[1])))
            {
                Console.WriteLine(Out);
            }
            return (T)parameters[1];
        }

        /// <summary>
        /// Reads the string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="In">message before entering value.</param>
        /// <param name="Out">error message.</param>
        /// <param name="valid">Validate function</param>
        public static string ReadString(string In, string Out, Func<String, bool> valid) {
            Console.WriteLine(In);
            string ans = "";
            while (!valid(ans=Console.ReadLine())) {
                Console.WriteLine(Out);
            }
            return ans;
        }



        static void Main(string[] args)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict['L'] = 0;
            dict['F'] = 1;
            dict['R'] = 2;
            dict['B'] = 3;


            do
            {
                int Rows = Read<int>("Enter number of Rows", "Invalid number of rows, reenter pls", (x) => x > 0 && x < 50);
                int Columns = Read<int>("Enter number of Columns", "Invalid number of Columns, reenter pls", (x) => x > 0 && x < 50);

                Field field = new Field(Rows, Columns);

                Robot robot = new Robot();

                Move[] moves = new Move[4] { robot.L, robot.F, robot.R, robot.B };
                string path = ReadString("Enter robot's path", "Something wrong with robot's path, reenter pls", (str) => {
                    foreach(var el in str) {
                        if (!dict.ContainsKey(el)) {
                            return false;
                        }
                    }
                    return true;
                });

                Move movesContainer = delegate{};

                foreach (var el in path) {
                    movesContainer += moves[dict[el]];
                }
                movesContainer();

                Console.WriteLine($"Coordinates are ({robot.X}, {robot.Y})");

                PrintField(robot, field);

                Console.WriteLine("Press esc to exit");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
