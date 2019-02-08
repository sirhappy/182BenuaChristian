using System;

namespace task6
{

    public class RingFoundEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public RingFoundEventArgs(string message)
        {
            this.Message = message;
        }
    }

    public abstract class Creature
    {
        public string Name { get; private set; }

        public string Location { get; private set; }

        public virtual void RingIsFoundEventHandler(object sender, RingFoundEventArgs e) { }

        protected Creature() { }

        protected Creature(string name)
        {
            this.Name = name;
            this.Location = "Random";
        }

        protected Creature(string name, string location)
        {
            this.Name = name;
            this.Location = location;
        }
    }

    public class Wizard : Creature
    {
        public event EventHandler<RingFoundEventArgs> FoundRingEvent;

        public Wizard() : base() { }

        public Wizard(string name) : base(name) { }

        public Wizard(string name, string location) : base(name, location) { }

        public void OnFoundRingEventHandler()
        {
            Console.WriteLine($"{Name}: Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл!");
            FoundRingEvent?.Invoke(this, new RingFoundEventArgs("Ривендейл"));
        }
    }

    public class Human : Creature
    {
        public Human() : base() { }

        public Human(string name) : base(name) { }

        public Human(string name, string location) : base(name, location) { }

        public override void RingIsFoundEventHandler(object sender, RingFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Волшебник {((Wizard)sender).Name} позвал. Моя цель {e.Message}. Выхожу из {Location}");
        }
    }

    public class Elf : Creature
    {
        public Elf() : base() { }

        public Elf(string name) : base(name) { }

        public Elf(string name, string location) : base(name, location) { }

        public override void RingIsFoundEventHandler(object sender, RingFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Звезды в {Location} светят не так как обычно. Цветы увядают. Листья предсказывают идти в " + e.Message);
        }
    }

    public class Dwarf : Creature
    {
        public Dwarf() : base() { }

        public Dwarf(string name) : base(name) { }

        public Dwarf(string name, string location) : base(name, location) { }

        public override void RingIsFoundEventHandler(object sender, RingFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Точим топоры, собираем припасы! Выдвигаемся из {Location} в " + e.Message);
        }
    }

    public class Hobbit : Creature
    {
        public Hobbit() : base() { }

        public Hobbit(string name) : base(name) { }

        public Hobbit(string name, string location) : base(name, location) { }

        public override void RingIsFoundEventHandler(object sender, RingFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Покидаю {Location}! Иду в " + e.Message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard gendalf = new Wizard("Гендальф");
            Creature[] creatures = {new Dwarf("Гимли", "Blue Mountains"), new Dwarf("Глоин", "Blue Mountains"), 
            new Elf("Леголас", "Northern MirkWood"), new Hobbit("Бильбо", "Sheer"), new Hobbit("Фродо", "Sheer"), 
            new Hobbit("Сэм", "Sheer"), new Hobbit("Поппин", "Sheer"), new Human("Арагорн", "Strider at Bree"), 
            new Human("Боромир", "Dol Amroth") };
            foreach (var creature in creatures)
            {
                gendalf.FoundRingEvent += creature.RingIsFoundEventHandler;
            }
            gendalf.OnFoundRingEventHandler();
        }
    }
}
