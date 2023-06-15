    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ConsoleApp1
    {
        internal class TicketList
        {
            private List<Ticket> tickets;

            public TicketList()
            {
                tickets = new List<Ticket>();
            }

            public void AddTicket(Ticket ticket)
            {
                tickets.Add(ticket);
            }
        public void RemoveTicket(Ticket ticket)
        {
            tickets.Remove(ticket);
        }
            public List<Ticket> GetTickets()
            {
                return tickets;
            }
        }
    }
