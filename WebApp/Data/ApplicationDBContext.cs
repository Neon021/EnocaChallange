using ASP.NET_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<MovieModel>? MovieModels { get; set; }  
    }
}
