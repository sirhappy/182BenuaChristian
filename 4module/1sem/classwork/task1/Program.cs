using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace task1
{

    [Serializable]
    class Student
    {
        public string LastName { get; private set; }
        public int Grade { get; private set; }

        public Student(string name, int grade)
        {
            this.LastName = name;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"Name: {LastName}, Grade: {Grade}";
        }
    }

    [Serializable]
    class Group
    {
        public string Name { get; private set; }
        public Student[] Students { get; private set; }

        public Group(string name, Student[] students)
        {
            this.Name = name;
            this.Students = students;
        }

        public override string ToString()
        {
            var ans = $"{Name}:\n";
            foreach (var el in this.Students)
            {
                ans += el.ToString() + "\n";
            }
            return ans;

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Group group1 = new Group("Obama1", new Student[] { new Student("st11", 1), new Student("st12", 2) });
            Group group2 = new Group("Obama2", new Student[] { new Student("st21", 1), new Student("st22", 2) });
            {
                FileStream stream = new FileStream("data.ser", FileMode.OpenOrCreate);

                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, group1);
                stream.Close();
            }
            {
                FileStream stream = new FileStream("data.ser", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                var group = (Group)formatter.Deserialize(stream);
                Console.WriteLine(group);
            }

            {
                FileStream stream = new FileStream("soap.ser", FileMode.OpenOrCreate);
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, group1);
                formatter.Serialize(stream, group2);
                stream.Close();
            }

            {
                FileStream stream = new FileStream("soap.ser", FileMode.OpenOrCreate);
                SoapFormatter formatter = new SoapFormatter();

                var group = (Group)formatter.Deserialize(stream);
                Console.WriteLine(group);

                group = (Group)formatter.Deserialize(stream);
                Console.WriteLine(group);

            }

            Console.WriteLine("Hello World!");
        }
    }
}
