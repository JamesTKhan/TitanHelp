using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TitanHelp.Pages
{
    public class FormsModel : PageModel
    {
        private readonly ILogger<FormsModel> _logger;

        public FormsModel(ILogger<FormsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        protected void save_Click(object sender, EventArgs e)
        {
            // Later this function will need to read 3? (2 if date is automatic) fields from the UI to create a new ticket object
            

        }
    }

}
