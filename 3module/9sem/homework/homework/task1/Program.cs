using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{

    public static class Generator
    {
        /// <summary>
        /// static Random instance
        /// </summary>
        public static Random rnd = new Random();

        /// <summary>
        /// Generate double between mn and mx.
        /// </summary>
        /// <returns>The generate.</returns>
        /// <param name="mn">Min value </param>
        /// <param name="mx">Max value</param>
        public static double Generate(double mn, double mx)
        {
            return rnd.NextDouble() * (mx - mn) + mn;
        }
        /// <summary>
        /// Generates the int between mn and mx
        /// </summary>
        /// <returns>The int.</returns>
        /// <param name="mn">Min value.</param>
        /// <param name="mx">Max value</param>
        public static int GenerateInt(int mn, int mx)
        {
            return rnd.Next(mn, mx);
        }
        /// <summary>
        /// Generates the string of lenght between mnLen and mxLen
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="mnLen">Mimimum length.</param>
        /// <param name="mxLen">Maximum length.</param>
        public static string GenerateString(int mnLen, int mxLen)
        {
            int len = rnd.Next(mnLen, mxLen);
            string ans = "";
            for (int i = 0; i < len; ++i)
            {
                ans += (char)(rnd.Next('a', 'z' + 1));
            }
            return ans;
        }
    }

        class Program
    {

        public class Student
        {
            public string FirstName { get; private set; }

            public string LastName { get; private set; }

            public double MathGrade { get; private set; }

            public double ProgGrade { get; private set; }

            public double EngGrade { get; private set; }

            public Student()
            {
                FirstName = LastName = "";
                MathGrade = ProgGrade = EngGrade = 0;
            }

            public Student(string fName, string sName, double mathGrade, double progGrade, double engGrade)
            {
                this.FirstName = fName;
                this.LastName = sName;
                this.MathGrade = mathGrade;
                this.ProgGrade = progGrade;
                this.EngGrade = engGrade;
            }

            public static Student MakeStudent()
            {
                return new Student(Generator.GenerateString(3, 5), Generator.GenerateString(3, 5),
                                    Generator.Generate(0, 10), Generator.Generate(0, 10), Generator.Generate(0, 10));
            }

            public override string ToString()
            {
                return $"{FirstName}, {LastName}, {MathGrade:F3}, {ProgGrade:F3}, {EngGrade:F3}";
            }
        }

        public static void WriteToFile(int n)
        {
            List<String> serializedStudents = new List<String>();
            for (int i = 0; i < n; ++i)
            {
                serializedStudents.Add(Student.MakeStudent().ToString());
            }

            File.WriteAllLines("students.txt", serializedStudents.ToArray());

        }

        public static void ReadFromFile()
        {
            List<Student> students = new List<Student>();
            File.ReadAllLines("students.txt").ToList().ForEach(el =>
            {
                var comps = el.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                var currentStudent = new Student(comps[0], comps[1], double.Parse(comps[2]), double.Parse(comps[3]), double.Parse(comps[4]));
                Console.WriteLine(currentStudent);
                students.Add(currentStudent);
            });

            students.ForEach(el => el.ToString());

            var res = students.OrderBy(el => el.EngGrade + el.MathGrade + el.ProgGrade).ToList();
            Console.WriteLine(res[0]);
            Console.WriteLine(res.Last());

        }

        static void Main(string[] args)
        {
            WriteToFile(20);
            ReadFromFile();
            Console.ReadKey();
        }
    }
}
