using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TitanHelp.Data;
using TitanHelp.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace TitanHelp.Pages
{
    public class FormsModel : PageModel
    {
        private readonly ILogger<FormsModel> _logger;
        private readonly ITicketDb _ticketDb;

        public FormsModel(ILogger<FormsModel> logger, TicketDb ticketDb)
        {
            _logger = logger;
            _ticketDb = ticketDb;   
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Later this function will need to read 3? (2 if date is automatic) fields from the UI to create a new ticket object

            string Name = Request.Form["name"];
            string Date = Request.Form["date"];
            string Desc = Request.Form["description"]; 

            var ticket = new Ticket
            {
                ClientName = Name,
                Date = DateTime.Parse(Date),
                Description = Desc
            };

            _ticketDb.SaveTicket(ticket);

            Response.Redirect("/main");

        }
    }

}
