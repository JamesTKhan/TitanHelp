using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TitanHelp.Data;
using TitanHelp.Models;

namespace TitanHelp.Pages
{
    public class FormsModel : PageModel
    {
        private readonly ILogger<FormsModel> _logger;
        private readonly ITicketDb _ticketDb;

        public FormsModel(ILogger<FormsModel> logger, ITicketDb ticketDb)
        {
            _logger = logger;
            _ticketDb = ticketDb;   
        }

        public void OnGet()
        {
        }

        public void save_Click(object sender, EventArgs e)
        {
            // Later this function will need to read 3? (2 if date is automatic) fields from the UI to create a new ticket object

            var ticket = new Ticket
            {
                ClientName = "James",
                Description = "This is a test ticket"
            };

            _ticketDb.SaveTicket(ticket);

        }
    }

}
