using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class Admin
    {
        private ListEmP employeeList;
        private ListMovie movieList;
        private TicketList ticketList;
        private Ticket ticket;

        public Admin()
        {
            employeeList = new ListEmP();
            movieList = new ListMovie();
            ticketList = new TicketList();
            ticket = new Ticket();
        }

        public void Run()
        {
            bool continueAdding = true;

            while (continueAdding)
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display Employees");
                Console.WriteLine("3. Remove Employee");
                Console.WriteLine("4. Add Movie");
                Console.WriteLine("5. Display Movies");
                Console.WriteLine("6. Remove Movie");
                Console.WriteLine("7. Sell Tickets");
                Console.WriteLine("8. Exit");
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
                        SellTickets();
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
        }

        private void SellTickets()
        {
            Console.WriteLine("What movie do you want:");
            string movieSelected = Console.ReadLine();
            ticket.SelectMovie(movieSelected, movieList);
            ticket.PrintTicketInfo();

            bool movieFound = (ticket.Movie != null);

            if (movieFound)
            {
                Console.WriteLine("1. Continue to payment");
                Console.WriteLine("2. Want to change movie");
                string choose = Console.ReadLine();

                if (choose == "1")
                {
                    ProcessPayment(movieSelected);
                }
                else if (choose == "2")
                {
                    ChangeMovie();
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            else
            {
                Console.WriteLine("Movie not found in the list. Payment ID is not required.");
                return;
            }
        }

        private void ChangeMovie()
        {
            Console.WriteLine("What movie do you want to change:");
            string newSelectedMovie = Console.ReadLine();
            ticket.SelectMovie(newSelectedMovie, movieList);
            ticket.PrintTicketInfo();

            bool movieFound = (ticket.Movie != null);

            if (movieFound)
            {
                Console.WriteLine("1. Continue to payment");
                string choose = Console.ReadLine();

                if (choose == "1")
                {
                    ProcessPayment(newSelectedMovie);
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            else
            {
                Console.WriteLine("Movie not found in the list. Payment ID is not required.");
            }
        }

        private void ProcessPayment(string movieSelected)
        {
            Console.WriteLine("Payment ID:");
            string paymentID = Console.ReadLine();
            Payment payment = new Payment(paymentID, DateTime.Now);
            Console.WriteLine("How many tickets do you want to purchase?");
            int numberOfTickets = int.Parse(Console.ReadLine());
            Console.WriteLine("You will buy " + numberOfTickets + " " + movieSelected + " movie tickets");

            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine("1. Do you want to proceed with payment?");
                Console.WriteLine("2. Do you want to add number of tickets?");
                Console.WriteLine("3. Do you want to remove numebr of tickets?");
                Console.WriteLine("4. Remove ticket");
                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        payment.NumberOfTicket = numberOfTickets;
                        for (int i = 0; i < numberOfTickets; i++)
                        {
                            ticketList.AddTicket(ticket);
                        }
                        Console.WriteLine("1.To print ticket");
                        Console.WriteLine("2. remove ticket");
                        string choose1 = Console.ReadLine();
                        if(choose1 == "1")
                        {
                            payment.AssignTicket(ticket);
                        }
                        if(choose1 == "2") {
                            payment.RemoveTicket(ticket);
                        }
                        payment.PrintPaymentInfo();

                        validChoice = true;
                        break;
                    case "2":
                        Console.WriteLine("How many tickets do you want to add?");
                        int newTicketsToAdd = int.Parse(Console.ReadLine());
                        int totalAfterAdd = newTicketsToAdd + numberOfTickets;
                        payment.NumberOfTicket = totalAfterAdd;
                        for (int i = 0; i < totalAfterAdd; i++)
                        {
                            ticketList.AddTicket(ticket);
                        }

                        Console.WriteLine("1.To print ticket");
                        Console.WriteLine("2. remove ticket");
                        string choose2 = Console.ReadLine();
                        if (choose2 == "1")
                        {
                            payment.AssignTicket(ticket);
                          }
                        if (choose2 == "2")
                        {
                            payment.RemoveTicket(ticket);
                        }
                        payment.PrintPaymentInfo();

                        validChoice = true;
                        break;
                    case "3":
                        Console.WriteLine("How many tickets do you want to remove?");
                        int newTicketsToRemove = int.Parse(Console.ReadLine());
                        if (newTicketsToRemove > numberOfTickets)
                        {
                            Console.WriteLine("Cannot remove more tickets than the current number of tickets.");
                        }
                        else
                        {
                            int totalAfterRemove = numberOfTickets - newTicketsToRemove;
                            payment.NumberOfTicket = totalAfterRemove;
                            for (int i = 0; i < totalAfterRemove; i++)
                            {
                                ticketList.AddTicket(ticket);
                            }

                            Console.WriteLine("1.To print ticket");
                            Console.WriteLine("2. remove ticket");
                            string choose3 = Console.ReadLine();
                            if (choose3 == "1")
                            {
                                payment.AssignTicket(ticket);
                       }
                            if (choose3 == "2")
                            {
                                payment.RemoveTicket(ticket);
                            }
                            payment.PrintPaymentInfo();

                            validChoice = true;
                        }
                        break;
                    case "4":
                         ticketList.RemoveTicket(ticket);
                        Console.WriteLine("remove ticket succesfully");
                        payment.PrintPaymentInfo();
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

    }
}
