using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ListEmP: Idata
    {
        private List<Employee> employees;
        public ListEmP()
        {
            employees = new List<Employee>();
        }
        public void Add()
        {
            Console.WriteLine("Enter Employee Details:");
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("Phone: ");
            string Phone = Console.ReadLine();
            Console.Write("Email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("ID:");
            int EmployeeId = int.Parse(Console.ReadLine());
            Employee employee = new Employee(Name,Phone,Email,EmployeeId);
            employees.Add(employee);
        }
        public void Remove()
        {
            Console.WriteLine("Input Id you want to remove");
            int id = int.Parse(Console.ReadLine());
            Employee employeeToRemove = employees.Find(employee => employee.EmployeeId == id);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                Console.WriteLine("Employee removed successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }



        public void DisplayEmployees()
        {
            foreach (Employee employee in employees)
            {
                employee.PrintInfo();
                Console.WriteLine("--------------------");
            }
        }
    }
}
