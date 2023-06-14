using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Customer: Person
    {
        private int age;
        public Customer() { }
        public int Age { get{return age;}
            set
            {
                age = value;
            }
        }
        public Customer(string name, string phone, string email,int age): base(name,phone,email)
        {
            Age = age;
        }
        public void EnterCustomer()
        {
            Console.WriteLine("Enter customer details:");
            Console.Write("Name: ");
            Name = Console.ReadLine();
            Console.Write("Age: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Phone: ");
            Phone = Console.ReadLine();
            Console.Write("Email: ");
            Email = Console.ReadLine();
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Age:"+ Age);
        }
    }
}
