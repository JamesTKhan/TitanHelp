using TitanHelp.Models;

namespace TitanHelp.Data
{
    /// <summary>
    /// Stubs out the Ticket database so every one
    /// does not have to run a database on their machine
    /// to test the application. Only for in-memory use, will not persist data.
    /// </summary>
    public class StubTicketDb : ITicketDb
    {
        // "In-memory" database
        private readonly List<Ticket> _tickets = [];
        
        public void SaveTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public void DeleteTicket(int ticketId)
        {
            var ticket = GetTicket(ticketId);
            if (ticket == null) return;
            _tickets.Remove(ticket);
        }

        public Ticket? GetTicket(int ticketId)
        {
            return _tickets.FirstOrDefault(t => t.Id == ticketId);
        }

        public List<Ticket> GetTickets()
        {
            // Return a copy of the list to prevent modification
            return _tickets.ToList();
        }
    }
}
