using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TitanHelp.Data;
using TitanHelp.Models;

namespace TitanHelp.Test;

/// <summary>
/// Creates and uses a test database to run tests on.
/// </summary>
[TestClass]
public class DatabaseTest
{
    private string TestDbPath => Path.Combine(AppContext.BaseDirectory, "test.db");
    
    [TestMethod]
    public void TestCreateTicket()
    {
        var ticket = new Ticket
        {
            ClientName = "James",
            Description = "This is a test ticket"
        };

        // Save
        var db = GetDb();
        db.SaveTicket(ticket);
        
        // Retrieve
        var retrievedTicket = db.GetTicket(ticket.Id);
        Assert.IsNotNull(retrievedTicket);
        Assert.AreEqual(ticket.Id, retrievedTicket.Id);
        Assert.AreEqual(ticket.ClientName, retrievedTicket.ClientName);
        Assert.AreEqual(ticket.Description, retrievedTicket.Description);
        
        // Delete
        db.DeleteTicket(ticket.Id);
        Assert.IsNull(db.GetTicket(ticket.Id));
    }
    
    [TestMethod]
    public void TestGetTickets()
    {
        var ticket1 = new Ticket
        {
            ClientName = "James",
            Description = "This is a test ticket"
        };
        var ticket2 = new Ticket
        {
            ClientName = "John",
            Description = "This is another test ticket"
        };

        // Save
        var db = GetDb();
        db.SaveTicket(ticket1);
        db.SaveTicket(ticket2);
        
        // Retrieve
        var tickets = db.GetTickets();
        Assert.AreEqual(2, tickets.Count);
        Assert.AreEqual(ticket1.Id, tickets[0].Id);
        Assert.AreEqual(ticket2.Id, tickets[1].Id);
        
        // Delete
        db.DeleteTicket(ticket1.Id);
        db.DeleteTicket(ticket2.Id);
        Assert.AreEqual(0, db.GetTickets().Count);
    }
    
    [TestMethod]
    public void TestEmptyTicket()
    {
        var ticket = new Ticket();

        var db = GetDb();
        Assert.ThrowsException<ValidationException>(() => db.SaveTicket(ticket));
    }
    
    [TestMethod]
    public void TestEmptyClientName()
    {
        var ticket = new Ticket
        {
            ClientName = "",
            Description = "This is a test ticket"
        };

        var db = GetDb();
        Assert.ThrowsException<ValidationException>(() => db.SaveTicket(ticket));
    }
    
    [TestMethod]
    public void TestEmptyDescription()
    {
        var ticket = new Ticket
        {
            ClientName = "James",
            Description = ""
        };

        var db = GetDb();
        Assert.ThrowsException<ValidationException>(() => db.SaveTicket(ticket));
    }

    private TicketDb GetDb()
    {
        var options = new DbContextOptionsBuilder<TicketDb>()
            .UseSqlite($"Data Source={TestDbPath}")
            .Options;
        var db = new TicketDb(options);
        db.Database.Migrate();
        return db;
    }
}