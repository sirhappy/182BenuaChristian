using System;
using Cinderella;
using System.Collections.Generic;

namespace CinderellaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Something[] array = new Something[10];
            for (int i = 0; i < array.Length; ++i) {
                if (Something.rnd.Next(0,2) == 0) {
                    array[i] = new Lentil();
                } else {
                    array[i] = new Ashes(); 
                }
                Console.WriteLine(array[i]);
            }
            List<Ashes> ashes = new List<Ashes>();
            List<Lentil> lentils = new List<Lentil>();
            for (int i = 0; i < array.Length; ++i) {
                if (array[i] is Lentil) {
                    lentils.Add(array[i] as Lentil);
                } else {
                    ashes.Add(array[i] as Ashes);
                }
            }
            foreach(var el in ashes) {
                Console.WriteLine(el);
            }

            Console.WriteLine();

            foreach (var el in lentils) {
                Console.WriteLine(el);
            }
        }
    }
}
