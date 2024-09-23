using System.ComponentModel.DataAnnotations;

namespace TitanHelp.Domain
{
    public class Ticket
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        public string ClientName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
