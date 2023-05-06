using System.ComponentModel.DataAnnotations;

namespace VeriAnalizi.Models
{
    public class KullaniciMesajEkleme
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        public string KullaniciYorumu { get; set; }

    }
}
