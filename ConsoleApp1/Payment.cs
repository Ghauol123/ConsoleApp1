using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Payment
    {
        private string paymentId;
        private decimal amount;
        private DateTime paymentDate;
        private TicketList ticketList;
        private int numberOfTicket;

        public string PaymentID
        {
            get { return paymentId; }
            set { paymentId = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public TicketList TicketList
        {
            get { return ticketList; }
            set { ticketList = value; }
        }

        public int NumberOfTicket
        {
            get { return numberOfTicket; }
            set { numberOfTicket = value; }
        }

        public Payment(string paymentID, DateTime paymentDate)
        {
            PaymentID = paymentID;
            Amount = 100;
            PaymentDate = paymentDate;
            TicketList = new TicketList();
        }

        public Payment()
        {
        }

        public void AssignTicket(Ticket ticket)
        {
            TicketList.AddTicket(ticket);
        }

        public void RemoveTicket(Ticket ticket)
        {
            TicketList.RemoveTicket(ticket);
        }

        public void PrintPaymentInfo()
        {
            Console.WriteLine("Payment Information:");
            Console.WriteLine("Payment ID: " + PaymentID);
            Console.WriteLine("Payment Date: " + PaymentDate);

            List<Ticket> tickets = TicketList.GetTickets();

            if (tickets.Count > 0)
            {
                Console.WriteLine("Tickets:");

                foreach (Ticket ticket in tickets)
                {
                    Console.WriteLine("Ticket ID: " + ticket.TicketID);
                    Console.WriteLine("Movie: " + ticket.Movie.Name);
                    Console.WriteLine("Year: " + ticket.Movie.Year);
                    Console.WriteLine("Genre: " + ticket.Movie.Genre);
                    Console.WriteLine("Age Limit: " + ticket.Movie.AgeLimit);
                    Console.WriteLine("Name's Customer: " + ticket.Customer.Name);
                    Console.WriteLine("Phone's Customer: " + ticket.Customer.Phone);
                    Console.WriteLine("Email's Customer: " + ticket.Customer.Email);
                    Console.WriteLine("Age's Customer: " + ticket.Customer.Age);
                }
                decimal totalAmount = NumberOfTicket * amount;
                Console.WriteLine("Total Amount: " + totalAmount);
            }
            else
            {
                Console.WriteLine("No associated tickets.");
            }
        }
    }
}
