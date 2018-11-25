using System;

namespace Cinderella
{
    public abstract class Something
    {
        static public Random rnd = new Random();
    }

    public class Lentil : Something {
        public double Weight { get; private set; }

        public Lentil() { Weight = rnd.NextDouble() * 2; }

        public Lentil(double w) {
            Weight = w;
        }
        public override string ToString()
        {
            return $"Lentil with weight : {Weight}";
        }
    }

    public class Ashes : Something {
        public double Volume { get; private set; }
        public Ashes() {
            Volume = rnd.NextDouble();
        }

        public Ashes(double v) {
            Volume = v;
        }
        public override string ToString()
        {
            return $"Ashes with Volume : {Volume}";
        }
    }
}
