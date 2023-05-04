using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeriAnalizi.Models
{
    public class Yorumlar
    {
        [Key] 

        public int Id { get; set; }
        [Required] 
        public string Ad { get; set; }
        [Required]
        public string Yorum { get; set; }
        [Required]
        public string Email { get; set; }

        public string Image { get; set; }
      
       
        public int YorumId { get; set; } 

    }
}
