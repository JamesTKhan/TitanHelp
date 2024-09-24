using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitanHelp.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        
        [Required]
        [MaxLength(100)]
        public string ClientName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
