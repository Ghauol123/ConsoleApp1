﻿using System;

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
                Console.WriteLine("7. Buy Tickets");
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
                        Console.WriteLine("What movie do you want:");
                        string movieSelected = Console.ReadLine();
                        ticket.SelectMovie(movieSelected, movieList);
                        ticket.PrintTicketInfo();

                        bool movieFound = (ticket.Movie != null);

                        if (movieFound)
                        {
                            Console.WriteLine("Payment ID:");
                            string paymentID = Console.ReadLine();
                            Payment payment = new Payment(paymentID, DateTime.Now);
                            Console.WriteLine("How many tickets do you want to purchase?");
                            int numberOfTickets = int.Parse(Console.ReadLine());
                            payment.NumberOfTicket = numberOfTickets;
                            Console.WriteLine("You will buy " + numberOfTickets + " " + movieSelected + " movie tickets");

                            for (int i = 0; i < numberOfTickets; i++)
                            {
                                ticketList.AddTicket(ticket); // Thêm vé vào danh sách vé chung (ticketList)
                            }
                            payment.AssignTicket(ticket); // Gán vé cho thanh toán
                            payment.PrintPaymentInfo();
                        }
                        else
                        {
                            Console.WriteLine("Movie not found in the list. Payment ID is not required.");
                        }
                
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
