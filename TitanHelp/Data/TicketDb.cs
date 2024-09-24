using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TitanHelp.Models;

namespace TitanHelp.Data;

public class TicketDb(DbContextOptions<TicketDb> options) : DbContext(options), ITicketDb
{
    public DbSet<Ticket> Tickets { get; set; } = null!;

    public void SaveTicket(Ticket ticket)
    {
        // Validate first
        var validationContext = new ValidationContext(ticket, null, null);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(ticket, validationContext, validationResults, true))
        {
            throw new ValidationException(validationResults.First().ErrorMessage);
        }
        
        Tickets.Add(ticket);
        SaveChanges();
    }

    public void DeleteTicket(int ticketId)
    {
        var ticket = GetTicket(ticketId);
        if (ticket == null) return;
        Tickets.Remove(ticket);
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