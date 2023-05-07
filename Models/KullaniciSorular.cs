using System.ComponentModel.DataAnnotations;

namespace VeriAnalizi.Models
{
    public class KullaniciSorular
    {
        [Key]
        public int Id { get; set; }
        public string Soru { get; set; }
        public string Secenek1 { get; set; }
        public string Secenek2 { get; set; }
        public string Secenek3 { get; set; }
        public string Secenek4 { get; set; }
    }
}
