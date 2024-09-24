using Microsoft.EntityFrameworkCore;
using TitanHelp.Models;

namespace TitanHelp.Data;

public class TicketDb(DbContextOptions<TicketDb> options) : DbContext(options), ITicketDb
{
    public DbSet<Ticket> Tickets { get; set; } = null!;

    public void SaveTicket(Ticket ticket)
    {
        Tickets.Add(ticket);
        SaveChanges();
    }

    public Ticket? GetTicket(int ticketId)
    {
        return Tickets.FirstOrDefault(t => t.Id == ticketId);
    }

    public List<Ticket> GetTickets()
    {
        return Tickets.ToList();
    }
}