using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Ticket
    {
        private string ticketId;
        private Customer customer;
        private Movie movie;
        private List<Customer> customers;
        private static Random random = new Random();

        public Ticket()
        {
            customers = new List<Customer>();
            ticketId = GenerateTicketId();
        }

        public string TicketID { get { return ticketId; } set { ticketId = value; } }
        public Movie Movie { get { return movie; } }
        public Customer Customer { get { return customer; } }

        public Ticket(string ticketID)
        {
            TicketID = ticketID;
            customers = new List<Customer>();
        }

        private string GenerateTicketId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomId = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomId;
        }

        public void SelectMovie(string movieTitle, ListMovie listMovie)
        {
            movie = listMovie.GetMovieByTitle(movieTitle);

            if (movie == null)
            {
                Console.WriteLine("Invalid movie selection.");
                return;
            }

            if (movie is KidMovie kidMovie)
            {
                Console.WriteLine("Your name:");
                string name = Console.ReadLine();
                Console.WriteLine("Your phone:");
                string phone = Console.ReadLine();
                Console.WriteLine("Your email:");
                string email = Console.ReadLine();
                Console.WriteLine("Your Age");
                int age = int.Parse(Console.ReadLine());

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
            else if (movie is AdultMovie adultMovie)
            {
                Console.WriteLine("Your name:");
                string name = Console.ReadLine();
                Console.WriteLine("Your phone:");
                string phone = Console.ReadLine();
                Console.WriteLine("Your email:");
                string email = Console.ReadLine();
                Console.WriteLine("Your Age");
                int age = int.Parse(Console.ReadLine());

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
            bool isMovieSelected = Movie != null;
            if (isMovieSelected)
            {
                Console.WriteLine("Ticket Information:");
                Console.WriteLine("Ticket ID: " + TicketID);
                Console.WriteLine("Movie: " + Movie.Name);
                Console.WriteLine("Year: " + Movie.Year);
                Console.WriteLine("Genre: " + Movie.Genre);
                Console.WriteLine("Age Limit: " + Movie.AgeLimit);
                Console.WriteLine("Customer Name: " + Customer.Name);
                Console.WriteLine("Customer Phone: " + Customer.Phone);
                Console.WriteLine("Customer Email: " + Customer.Email);
                Console.WriteLine("Customer Age: " + Customer.Age);
            }
            else
            {
                Console.WriteLine("No movie selected.");
            }
        }
    }
}
