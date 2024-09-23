using TitanHelp.Models;

namespace TitanHelp.Data
{
    /// <summary>
    /// Interface for interacting with the ticket database
    /// </summary>
    public interface ITicketDb
    {
        /// <summary>
        /// Saves a ticket to the database
        /// </summary>
        /// <param name="ticket"></param>
        void SaveTicket(Ticket ticket);
        
        /// <summary>
        /// Gets a ticket from the database. Returns null if not found.
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        Ticket? GetTicket(int ticketId);
        
        /// <summary>
        /// Gets all tickets from the database
        /// In real life this would be paginated
        /// </summary>
        /// <returns></returns>
        List<Ticket> GetTickets();
    }
}
