using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ListEmP employeeList = new ListEmP();
            ListMovie movieList = new ListMovie();
            TicketList ticketList = new TicketList();
            Ticket ticket = new Ticket();

            bool continueAdding = true;

            while (continueAdding)
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display Employees");
                Console.WriteLine("3. Remove Employee");
                Console.WriteLine("4. Add Movie");
                Console.WriteLine("5. Display Movies");
                Console.WriteLine("6. Remove Movie");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        employeeList.Add();
                        break;
                    case "2":
                        employeeList.DisplayEmployees();
                        break;
                    case "3":
                        employeeList.Remove();
                        break;
                    case "4":
                        movieList.Add();
                        break;
                    case "5":
                        movieList.DisplayMovies();
                        break;
                    case "6":
                        movieList.Remove();
                        break;
                    case "7":
                        Console.WriteLine("What your movie you want :");
                        string movieselected = Console.ReadLine();
                        ticket.SelectMovie(movieselected,movieList);
                        ticket.PrintTicketInfo();
                        ticketList.AddTicket(ticket);
                        Console.WriteLine("Payment id:");
                        string paymentID = Console.ReadLine();
                        Console.WriteLine("Amount:");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        Payment payment = new Payment(paymentID,amount,DateTime.Now);
                        payment.AssignTicket(ticket);
                        payment.PrintPaymentInfo();
                        break;
                    case "8":
                        continueAdding = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
