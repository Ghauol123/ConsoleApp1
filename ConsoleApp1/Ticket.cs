using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
        private List<Customer> customers;
        public Ticket() {
            customers = new List<Customer>();
    }
        public string TicketID { get { return ticketId; } set { ticketId = value; } }
        public Movie SelectedMovie { get { return movie; } }
        public Customer Customer { get { return customer; } }

        public Ticket(string ticketID)
        {
            TicketID = ticketID;
            customers = new List<Customer>();
        }
        public void SelectMovie(string movieTitle, ListMovie listMovie)
        {
            movie = listMovie.GetMovieByTitle(movieTitle);

            if (movie is AdultMovie adultMovie)
            {
                Console.WriteLine("Your name:");
                string name = Console.ReadLine();
                Console.WriteLine("Your Age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Your phone:");
                string phone = Console.ReadLine();
                Console.WriteLine("Your email:");
                string email = Console.ReadLine();

                if (age < adultMovie.AgeLimit)
                {
                    Console.WriteLine("You are not old enough to watch this movie.");
                    movie = null; // Reset movie selection
                }
                else
                {
                    if (movie != null)
                    {
                        customer = new Customer(name, phone, email, age);
                        customers.Add(customer);
                    }
                    else
                    {
                        Console.WriteLine("Invalid movie selection.");
                    }
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
                Console.WriteLine("Name's Customer: " + customer.Name);
                Console.WriteLine("Phone's Customer: " + customer.Phone);
                Console.WriteLine("Email's Customer: "+ customer.Email);
                Console.WriteLine("Age's Customer: " + customer.Age);
            }
            else
            {
                Console.WriteLine("No movie you want");
            }
        }
    }
}
