using System.ComponentModel.DataAnnotations;

namespace WebProje1.Models
{
    public class Booking
    {
        [Key]
        public int MusteriId { get; set; }

        [Required(ErrorMessage = "Müşteri adı boş geçilemez!")]
        public string? MusteriAdi { get; set; }
        [Required(ErrorMessage = "Müşteri telefon numarası boş geçilemez!")]
        public string? MusteriTelNo { get; set; }
        [Required(ErrorMessage = "Müşteri adresi boş geçilemez!")]
        public string? MusteriAdresi { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime GirisTarihi { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime CikisTarihi { get; set; }

        
        public int KalacakKisiSayisi { get; set; }
    }
}
