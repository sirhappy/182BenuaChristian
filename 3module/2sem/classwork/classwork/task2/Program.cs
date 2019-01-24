using System;

namespace task2
{

    public class Car
    {

        public delegate void CarEngineHandler(string message);

        private CarEngineHandler handlers = null;

        public void RegisterCallBack(CarEngineHandler handler)
        {
            handlers += handler;
        }

        public int CurrentSpeed { get; private set; }
        public int MaxSpeed { get; private set; }
        public string CarName { get; private set; }
        private bool isWorking;

        public void Accelerate(int change)
        {
            if (!isWorking)
            {
                handlers?.Invoke("Car is dead, cant accelerate");
            }
            else
            {
                CurrentSpeed += change;
                if (CurrentSpeed > MaxSpeed)
                {
                    isWorking = false;
                    handlers?.Invoke("Car is dead, cant accelerate");

                }
                else
                {
                    handlers?.Invoke($"Car is accelerating!! Vrom Vrom, speed : {CurrentSpeed}");
                }
            }
        }

        public Car()
        {
            CurrentSpeed = MaxSpeed = 0;
            isWorking = true;
            CarName = "Default";
        }

        public Car(string name, int maxSp, int curSp)
        {
            isWorking = true;

            CarName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = curSp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("CarCarich", 120, 10);
            car.RegisterCallBack((message) => Console.WriteLine("Im from delegate: \n" + message));
            car.Accelerate(100);
            car.Accelerate(10);
            car.Accelerate(10);
        }
    }
}
