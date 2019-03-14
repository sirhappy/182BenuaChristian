using System;
using System.Reflection;

namespace task5
{

    public class Reader
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
    }

    public static class Generator
    {
        public static Random rnd = new Random();
    }

    public abstract class Animal
    {
        public int Age { get; private set; }

        public Animal() { }

        public Animal(int age)
        {
            Age = age;
        }

        public override string ToString()
        {
            return $"Animal: Age: {Age}";
        }
    }

    public interface IBase
    {
        void Write();
    }

    public interface In1 : IBase
    {
        new void Write();
    }

    public interface In2: IBase
    {
        int Write(int i);
    }

    public class Kek : In1, In2
    {
       

        public int Write(int i)
        {
            return 1;
        }


    }

    public partial interface IJumpable
    {
        void Jump();
    }


    public interface IRunnable
    {
        void Run();
    }

    public class Cockroach : Animal, IRunnable
    {
        public int Speed { get; set; }

        public Cockroach(int age, int speed):base(age)
        {
            Speed = speed;
        }

        public void Run()
        {
            Console.WriteLine($"Tarakan is runnung with {Speed}");
        }

        public override string ToString()
        {
            return $"Taraka with age:{Age}, speed:{Speed}";
        }
    }

    public class Kangaroo : Animal, IJumpable
    {
        public int Length { get; set; }

        public Kangaroo(int age, int length) : base(age)
        {
            Length = length;
        }

        public void Jump()
        {
            Console.WriteLine($"Kangaroo jump on {Length} length");
        }

        public override string ToString()
        {
            return $"Kangaroo with age:{Age}, length:{Length}";
        }
    }

    public class Cheetah : Animal, IRunnable, IJumpable
    {

        public int Speed { get; set; }

        public int Length { get; set; }

        public Cheetah(int age, int speed, int legth) : base(age)
        {
            Speed = speed;
            Length = legth;
        }

        public void Run()
        {
            Console.WriteLine($"Cheetah runs with {Speed}");
        }
        public void Jump()
        {
            Console.WriteLine($"Cheetah jumps with len: {Length}");
        }

        public override string ToString()
        {
            return $"Cheetah with age:{Age}, speed:{Speed} and jump length: {Length}";
        }
    }


    class Program
    {

        public static Animal[] GetAnimals()
        {
            Animal[] arr = new Animal[10];

            for (int i = 0; i < arr.Length; ++i)
            {
                if (i % 3 == 0)
                {
                    arr[i] = new Cheetah(Generator.rnd.Next(10), Generator.rnd.Next(10), Generator.rnd.Next(10));
                }
                else if (i % 3 == 1)
                {
                    arr[i] = new Cockroach(Generator.rnd.Next(10), Generator.rnd.Next(10));
                }
                else
                {
                    arr[i] = new Kangaroo(Generator.rnd.Next(10), Generator.rnd.Next(10));
                }
                Console.WriteLine(arr[i]);
            }

            return arr;
        }

        static void Main(string[] args)
        {
            GetAnimals();
        }
    }
}
