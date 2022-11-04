using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASP.NET_Web.Models
{
    public class MovieDetailsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("FK_SalonId")]
        public int SalonId { get; set; }
        
        [ForeignKey("FK_MovieId")]
        public int MovieId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public MovieDetailsModel()
        {

        }
        public MovieDetailsModel(int _SalonId, int _MovieId, DateTime _ReleaseDate)
        {
            SalonId = _SalonId;
            MovieId = _MovieId;
            ReleaseDate = _ReleaseDate;
        }
    }
}
