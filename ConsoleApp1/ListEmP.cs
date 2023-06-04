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
        Employee employee = new Employee();
        public ListEmP()
        {
            employees = new List<Employee>();
        }
        public void Add()
        {
            Console.WriteLine("Enter Employee Details:");
            Console.Write("Name: ");
            employee.Name = Console.ReadLine();
            Console.Write("Phone: ");
            employee.Phone = Console.ReadLine();
            Console.Write("Email: ");
            employee.Email = Console.ReadLine();
            Console.WriteLine("ID:");
            employee.EmployeeId = int.Parse(Console.ReadLine());
            employees.Add(employee);
        }
        public void Remove()
        {
            Console.WriteLine("Enter the name of the employee to remove:");
            string nameToDelete = Console.ReadLine();

            Employee employeeToRemove = employees.FirstOrDefault(employee => employee.Name == nameToDelete);
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
