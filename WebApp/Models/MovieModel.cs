using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Web.Models
{
    public class MovieModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Required, StringLength(int .MaxValue)]
        public string? Name { get; set; }
        
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public string? Director { get; set; }


    }
}
