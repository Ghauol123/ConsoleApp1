using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ListMovie: Idata
    {
        private List<Movie> movies;
        KidMovie kidMovie = new KidMovie();
        AdultMovie adultMovie = new AdultMovie();
        public ListMovie()
        {
            movies = new List<Movie>();
        }
        public void Add()
        {
            Console.WriteLine("Choose the fiml you want to add:");
            Console.WriteLine("1. Kid Movie");
            Console.WriteLine("2. Adult Movie");
            int choose = int.Parse(Console.ReadLine());
            if(choose == 1)
            {
                Console.WriteLine("Name movie:");
                kidMovie.Name = Console.ReadLine();
                Console.WriteLine("Year's movie:");
                kidMovie.Year = int.Parse(Console.ReadLine());
                Console.WriteLine("Genre's movie");
                kidMovie.Genre = Console.ReadLine();
                Console.WriteLine("Age Limit:");
                kidMovie.AgeLimit = int.Parse(Console.ReadLine());
                movies.Add(kidMovie);
            }
            else if(choose == 2)
            {
                Console.WriteLine("Name movie:");
                adultMovie.Name = Console.ReadLine();
                Console.WriteLine("Year's movie:");
                adultMovie.Year = int.Parse(Console.ReadLine());
                Console.WriteLine("Genre's movie");
                adultMovie.Genre = Console.ReadLine();
                Console.WriteLine("Age Limit Movie:");
                adultMovie.AgeLimit = int.Parse(Console.ReadLine());
                movies.Add(adultMovie);
            }
            else
            {
                Console.WriteLine("Wrong!");
            }
        }
        public void Remove()
        {
            Console.WriteLine("Choose the film you want to remove:");
            Console.WriteLine("1. Kid Movie");
            Console.WriteLine("2. Adult Movie");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name of the movie to remove:");
            string nameToDelete = Console.ReadLine();

            Movie movieToRemove = null;

            if (choice == 1)
            {
                // Xóa phim trẻ em
                movieToRemove = movies.FirstOrDefault(movie => movie is KidMovie && movie.Name == nameToDelete);
            }
            else if (choice == 2)
            {
                // Xóa phim người lớn
                movieToRemove = movies.FirstOrDefault(movie => movie is AdultMovie && movie.Name == nameToDelete);
            }

            if (movieToRemove != null)
            {
                movies.Remove(movieToRemove);
                Console.WriteLine("Movie removed successfully.");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }
        public void DisplayMovies()
        {
            Console.WriteLine("Kid Movies:");
            Console.WriteLine("--------------------");
            foreach (Movie movie in movies)
            {
                if (movie is KidMovie)
                {
                    movie.displayInfor();
                    Console.WriteLine("--------------------");
                }
            }

            Console.WriteLine("Adult Movies:");
            Console.WriteLine("--------------------");
            foreach (Movie movie in movies)
            {
                if (movie is AdultMovie)
                {
                    movie.displayInfor();
                    Console.WriteLine("--------------------");
                }
            }
        }
        public Movie GetMovieByTitle(string title)
        {
            foreach (Movie movie in movies)
            {
                if (movie.Name == title)
                {
                    return movie;
                }
            }
            return null;
        }
    }
}
