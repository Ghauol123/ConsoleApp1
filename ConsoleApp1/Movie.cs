using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Movie
    {
        private string name;
        private int year;
        private string genre;
        private int ageLimit;
        public int Year { get { return year; } set { year = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Genre { get { return genre;}set { genre = value; } }
        public int AgeLimit { get { return ageLimit; }set { ageLimit = value; } }
        public Movie() { }

        public Movie(string name, int year, string genre,int ageLimit)
        {
            Name = name;
            Year = year;
            Genre = genre;
            AgeLimit = ageLimit;
        }
        public virtual void displayInfor()
        {
            Console.WriteLine("Movie information:");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Year: "+ Year);
            Console.WriteLine("Genre: " + Genre);
            Console.WriteLine("AgeLimit: "+  AgeLimit);
        }
    }
}
