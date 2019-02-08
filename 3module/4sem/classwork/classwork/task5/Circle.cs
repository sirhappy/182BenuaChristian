using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Circle
    {

        public event Action OnRadiusChanged;

        double _radius;

        public double Radius
        {
            get => _radius;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Radius), "Radius cant be negative");
                }
                _radius = value;
                OnRadiusChanged?.Invoke();
            }
        }

        public Circle() { }

        public Circle(double r)
        {
            Radius = r;
        }

    }
}
