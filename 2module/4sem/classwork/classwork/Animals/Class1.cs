using System;

namespace Animals
{
    public abstract class Animal {

        public abstract void AnimalSound();

        public abstract void AnimalInfo();
        
        public string Name { get; protected set; }
        int age;
        public int Age {
            get { return age; }
            protected set {
                if (value < 0 || value > 50) {
                    throw new ArgumentException("Age is below zero or too big");
                }
                age = value;
            }
        }

        protected Animal() {
            Name = "";
            Age = 0;
        }

        protected Animal(string name, int age) {
            Name = name;
            Age = age;
        }
    }

    public class Dog : Animal {
        public string Breed { get ; private set; }
        public bool IsTrained { get; private set; }

        public Dog() {
            Breed = "";
            IsTrained = false;
        }

        public Dog(string name, int age, string breed, bool isTrained) : base(name, age) {
            Breed = breed; IsTrained = isTrained;
        }

        public override void AnimalInfo()
        {
            Console.WriteLine($"Name : {Name}, Age : {Age}, Breed : {Breed}, Trained : {IsTrained}");
        }

        public override void AnimalSound()
        {
            Console.WriteLine("GAV GAV, GAAV GV");
        }
    }

    public class Cow : Animal {
        double milkLitresPerDay;
        public double MilkLitersPerDay {
            get { return milkLitresPerDay; } 
            private set {
                if (value < 0 || value > 100) {
                    throw new ArgumentException("MilkLitresPerDay below zero or too big(100)");
                }
                milkLitresPerDay = value;
            }
        }

        public Cow() {
            MilkLitersPerDay = 0;
        }

        public Cow(string name, int age, double milk) : base(name, age) {
            MilkLitersPerDay = milk;
        }

        public override void AnimalInfo()
        {
            Console.WriteLine($"Name : {Name}, Age : {Age}, milkLitres per day { MilkLitersPerDay}");
        }

        public override void AnimalSound()
        {
            Console.WriteLine("MOUUU");
        }
    }
}
