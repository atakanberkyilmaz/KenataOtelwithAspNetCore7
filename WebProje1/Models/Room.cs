using System.ComponentModel.DataAnnotations;

namespace WebProje1.Models
{
    public class Room
    {
        [Key]
        public int OdaId { get; set; }
        public string? OdaTuru { get; set; }
        public string? OdaFiyati { get; set; }
    }
}
