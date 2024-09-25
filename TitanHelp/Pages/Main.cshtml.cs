using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TitanHelp.Data;

namespace TitanHelp.Pages
{
    public class MainModel : PageModel
    {
        private readonly ILogger<MainModel> _logger;

        public MainModel(ILogger<MainModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void displayTickets() 
        {
            // This function will be for displaying the tickets currently in the stub database

        }

    }

}
