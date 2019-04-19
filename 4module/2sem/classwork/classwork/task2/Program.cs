
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using SerializationLib;

namespace task2
{

    [DataContract]
    public class Human
    {
        [DataMember]
        public string Name { get; private set; }

        public Human(string name)
        {
            this.Name = name;
        }
    }

    [DataContract]
    public class Professor : Human
    {
        [DataMember]
        public string Department { get; private set; }

        public Professor(string name, string dep): base(name)
        {
            this.Department = dep;
        }
    }

    [DataContract]
    public class Department
    {
        [DataMember]
        public string Name { get; private set; }
        
        [DataMember]
        public List<Human> Workers { get; private set; }

        public Department(string name, List<Human> workers)
        {
            this.Name = name;
            this.Workers = new List<Human>(workers);
        }
    }

    [DataContract]
    public class University
    {
        [DataMember]
        public string Name { get; private set; }
        
        [DataMember]
        public List<Department> Departments { get; private set; }

        public University(string name, List<Department> dep)
        {
            this.Name = name;
            this.Departments = new List<Department>(dep);
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Human> hum = (new Human[]{new Human("Obama"), new Professor("Avdoshka", "PI")}).ToList();
            var dep1 = new Department[] {new Department("PI", hum),};
            var university = new University("HSE", new List<Department>(dep1));
            var universities = new University[]{university};
            
            (new JSONCollectionSerializer<University>()).Serialize("univ.xml", universities, new Type[]
            {
                typeof(Department), 
                typeof(Professor),
                typeof(Human)
            });
            var ans = (new JSONCollectionDeserializer<University>()).Deserialize("univ.xml", new Type[]
            {
                typeof(Department), 
                typeof(Professor),
                typeof(Human)
            });
            Console.WriteLine(ans);
        }
    }
}