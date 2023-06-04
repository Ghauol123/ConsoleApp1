using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Payment
    {
        private string paymentId;
        private decimal amount;
        private DateTime paymentDate;
        private TicketList ticketList;

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

        public Payment(string paymentID, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            Amount = amount;
            PaymentDate = paymentDate;
            TicketList = new TicketList();
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
            Console.WriteLine("Amount: " + Amount);
            Console.WriteLine("Payment Date: " + PaymentDate);

            List<Ticket> tickets = TicketList.GetTickets();

            if (tickets.Count > 0)
            {
                Console.WriteLine("Tickets:");
                foreach (Ticket ticket in tickets)
                {
                    Console.WriteLine("Ticket ID: " + ticket.TicketID);
                    Console.WriteLine("Movie: " + ticket.SelectedMovie.Name);
                    Console.WriteLine("Year: " + ticket.SelectedMovie.Year);
                    Console.WriteLine("Genre: " + ticket.SelectedMovie.Genre);
                    Console.WriteLine("Age Limit: " + ticket.SelectedMovie.AgeLimit);
                    Console.WriteLine("Name's Customer: " + ticket.Customer.Name);
                    Console.WriteLine("Phone's Customer: " + ticket.Customer.Phone);
                    Console.WriteLine("Email's Customer: " + ticket.Customer.Email);
                    Console.WriteLine("Age's Customer: " + ticket.Customer.Age);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No associated tickets.");
            }
        }
    }
}
