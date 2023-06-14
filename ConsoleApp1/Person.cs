using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {

        private string name;
        private string phone;
        private string email;
        public string Name { get { return name; } set { name = value; } }
        public string Phone { get{return phone; } set { phone = value; } }
        public string Email { get{return email; } set { email = value; } }

        public Person() { }

        public Person(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Phone: " + Phone);
            Console.WriteLine("Email:" +  Email);
        }
    }
}
