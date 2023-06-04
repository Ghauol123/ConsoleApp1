using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ticket
    {
        private string ticketId;
        private Customer customer;
        private Movie movie;
        private List<Movie> movies;
        public Ticket() { }
        public string TicketID { get { return ticketId; } set { ticketId = value; } }
        public Movie SelectedMovie { get { return movie; } }

        public Ticket(string ticketID)
        {
            TicketID = ticketID;
        }
        public void SelectMovie(string movieTitle, ListMovie listMovie)
        {
            movie = listMovie.GetMovieByTitle(movieTitle);

            if (movie is AdultMovie adultMovie)
            {
                Console.WriteLine("Enter your age:");
                int age = int.Parse(Console.ReadLine());

                if (age < adultMovie.AgeLimit)
                {
                    Console.WriteLine("You are not old enough to watch this movie.");
                    //movie = null; // Reset movie selection
                    
                }
            }
        }
        public void PrintTicketInfo()
        {
            bool isMovieSelected = SelectedMovie != null;
            if (SelectedMovie != null)
            {
                Console.WriteLine("Ticket Information:");
                Console.WriteLine("Movie: " + SelectedMovie.Name);
                Console.WriteLine("Year: " + SelectedMovie.Year);
                Console.WriteLine("Genren: " + SelectedMovie.Genre);
                Console.WriteLine("Age Limit: " + SelectedMovie.AgeLimit);
            }
            else
            {
                Console.WriteLine("No movie you want");
            }
        }
    }
}
