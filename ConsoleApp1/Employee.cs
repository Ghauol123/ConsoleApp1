using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Employee: Person
    {
        private int employeeId;
        public Employee() { }
        public Employee(string name, string phone, string email, int employeeId): base(name, phone, email)
        {
            EmployeeId = employeeId;
        }
        public int EmployeeId { get { return employeeId; } set {  employeeId = value; } }
        public override void PrintInfo()
        {
            Console.WriteLine("Employee information:");
            Console.WriteLine("Id:" + EmployeeId);
            base.PrintInfo();
        }
    }
}
