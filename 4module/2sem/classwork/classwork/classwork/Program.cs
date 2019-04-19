using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using SerializationLib;

namespace classwork
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; private set; }
        
        [DataMember]
        public int Course { get; private set; }

        public Student(string name, int course)
        {
            this.Name = name;
            this.Course = course;
        }
    }

    [DataContract]
    public class Group
    {
        [DataMember]
        public string Name { get; private set; }
        
        [DataMember]
        public List<Student> Students { get; private set; }

        public Group(string name, List<Student> students)
        {
            this.Name = name;
            this.Students = students;
        }
    }
    
    
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var group1 = new Group("182", (new Student[]{new Student("A", 1), 
                new Student("B", 1) }).ToList());
            var group2 = new Group("183", (new Student[]{new Student("A3", 1), 
                new Student("B3", 1) }).ToList());

            {
                var arr = new Group[] {group1, group2};

                (new JSONCollectionSerializer<Group>()).Serialize("mydata.json", arr);
            }
            {
                var arr = (new JSONCollectionDeserializer<Group>()).Deserialize("mydata.json");
                arr.ToList().ForEach((el) => Console.WriteLine(el));
            }
        }
    }
}