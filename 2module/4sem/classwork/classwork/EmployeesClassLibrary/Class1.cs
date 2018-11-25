using System;
using EmployeesClassLibrary;


namespace EmployeesClassLibrary
{

   

    public class Employee
    {
        public string Name {
            get;
            private set;
        }

        protected double basePay;

        public Employee() {
            Name = "";
            basePay = 0;
        }

        public Employee(string name, double pay) {
            Name = name;
            basePay = pay;
        }

        public virtual double CalculatePay() {
            return basePay;
        }

        public override string ToString()
        {
            return $"Employee Name:{Name}, basePay:{basePay.ToString("F3")}";
        }
    }

    public class SalesEmployee : Employee {
        private double salesBonus;

        public SalesEmployee() : base() {
            salesBonus = 0;
        }

        public SalesEmployee(string Name, double basePay, double salesBonus) : base(Name, basePay) {
            this.salesBonus = salesBonus;
        }

        public override double CalculatePay()
        {
            return basePay + salesBonus;
        }
        public override string ToString()
        {
            return $"SalesEmployee Name:{Name}, basepay:{basePay.ToString("F3")}, salesBonus:{salesBonus}";
        }
    }

    public class PartTimeEmployee : Employee {
        private int workingDays;

        public PartTimeEmployee() : base() {
            workingDays = 0;
        }

        public PartTimeEmployee(string Name, double basePay, int workingDays) : base(Name, basePay) {
            this.workingDays = workingDays;
        }

        public override double CalculatePay()
        {
            return basePay * workingDays / 25;
        }

        public override string ToString()
        {
            return $"PartTimeEmployee Name:{Name}, BasePay:{basePay.ToString("F3")}, workingdays:{workingDays}";
        }
    }
}
