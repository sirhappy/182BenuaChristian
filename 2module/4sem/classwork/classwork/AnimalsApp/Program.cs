using System;
using Animals;
using System.Reflection;
namespace AnimalsApp
{
    class Program
    {
        public static T Read<T>(string In, string Out, Func<T, bool> valid) where T : struct
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

        static void Main(string[] args)
        {
            do
            {
                bool success = true;
                Console.WriteLine("Enter what object you want to create(Cow or Dog)");
                Console.WriteLine("If Dog, enter Name, Age(0,50), Breed, IsTrained(0 or 1) in diff lines");
                Console.WriteLine("If Cow, enter Name, Age(0,50), milkperday(0,100) in diff lines");
                Animal animal = new Dog();
                string[] arr;// Console.ReadLine().Split(' ');

                while ((arr=Console.ReadLine().Split(' '))[0] != "Dog" && arr[0] != "Cow") {
                    Console.WriteLine("Wrong type of animal");
                }

                string name = Console.ReadLine();
                int age = Read<int>("Age", "Smth wrong with age", (arg) => true);
                try
                {
                    if (arr[0] == "Dog")
                    {
                        string breed = Console.ReadLine();
                        bool trained = Read<int>("IsTrained?", "Smth wrong with IsTrained", (arg) => arg >= 0 && arg <= 1) == 0 ? false : true;
                        animal = new Dog(name, age, breed, trained);
                    }
                    else
                    {
                        double milk = Read<double>("Milk per day", "Smth wrong with Milk Per Day", (arg) => true);
                        animal = new Cow(name, age, milk);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    success = false;
                } finally {
                    if (success)
                    {
                        animal.AnimalInfo();
                        animal.AnimalSound();
                    }

                }

                Console.WriteLine("ESC");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
