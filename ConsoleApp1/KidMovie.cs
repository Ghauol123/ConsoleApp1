using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class KidMovie: Movie
    {   
        public KidMovie()
        {

        }
        public KidMovie(string name, int year, string genre,int ageLimit): base(name, year, genre,ageLimit)
        {
        }
        public override void displayInfor()
        {
            Console.WriteLine("Kid Movie Information:");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("Genre: " + Genre);
            Console.WriteLine("Age Limit: " + AgeLimit);
        }
    }   
}
