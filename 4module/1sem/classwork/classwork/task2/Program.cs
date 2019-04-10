using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace task2
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }

        public Human(string name)
        {
            this.Name = name;
        }

        public Human() { }
    }

    [Serializable]
    public class Professor: Human
    {
        public string DepName { get; set; }

        public Professor() { }

        public Professor(string name, string depName)
        {
            this.Name = name;
            this.DepName = depName;
        }
    }

    [Serializable]
    public class Departament
    {
        public List<Human> Employees { get; set; }
        public string DepName { get; set; }

        public Departament()
        {
            this.DepName = "";
            this.Employees = new List<Human>();
        }

        public Departament(List<Human> empl, string depName)
        {
            this.Employees = empl;
            this.DepName = depName;
        }
    }

    [Serializable]
    public class University
    {
        public List<Departament> Departaments { get; set; }
        public string UniversityName { get; set; }

        public University()
        {
            this.Departaments = new List<Departament>();
            this.UniversityName = "";
        }

        public University(string name, List<Departament> departaments)
        {
            this.UniversityName = name;
            this.Departaments = departaments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            University HSE = new University();
            HSE.UniversityName = "NRU HSE";
            Human[] deptStaff = { new Professor("Ivanov", "PI"),
                      new Professor("Petrov", "PI")
};
            Departament SE = new Departament( deptStaff.ToList(), "SE");
            HSE.Departaments = new List<Departament>();
            HSE.Departaments.Add(SE);


            University HSE1 = new University();
            HSE1.UniversityName = "NRU HSE";
            Human[] deptStaff1 = { new Professor("Ivanov2", "PI2"),
                      new Professor("Petrov2", "PI2")
};
            Departament SE2 = new Departament(deptStaff.ToList(), "SE2");
            HSE1.Departaments = new List<Departament>();
            HSE1.Departaments.Add(SE2);

            using (FileStream stream = new FileStream("xml.xml", FileMode.OpenOrCreate))
            {
                var formatter = new XmlSerializer(typeof(University[]), new Type[] { typeof(Departament), typeof(Professor), typeof(Human) });
                formatter.Serialize(stream, new University[] { HSE, HSE1 });
            }

            using (FileStream stream = new FileStream("xml.xml", FileMode.OpenOrCreate))
            {
                var formatter = new XmlSerializer(typeof(University[]), new Type[] { typeof(Departament), typeof(Professor), typeof(Human) });
                var obj = (University[])formatter.Deserialize(stream);
                Console.WriteLine(obj);
            }
        }
    }
}
