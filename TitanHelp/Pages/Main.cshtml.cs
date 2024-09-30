using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TitanHelp.Data;
using TitanHelp.Models;

namespace TitanHelp.Pages
{
    public class MainModel : PageModel
    {
        private readonly ILogger<MainModel> _logger;
        private readonly ITicketDb _ticketDb;

        public MainModel(ILogger<MainModel> logger, TicketDb ticketDb)
        {
            _logger = logger;
            _ticketDb = ticketDb;
        }

        public void OnGet()
        {
            DisplayTickets();
        }

        public List<Ticket> Tickets;

        public void DisplayTickets() 
        {
            // This function will be for displaying the tickets currently in the stub database

            if(_ticketDb.GetTickets() != null) 
            {
                Tickets = _ticketDb.GetTickets();
            }

        }

    }

}
