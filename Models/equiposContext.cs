using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using MVC_practica09_EsmeraldaGarcia.Models;

namespace MVC_practica09_EsmeraldaGarcia.Models
{

    public class equiposContext: DbContext 
    {
        public equiposContext(DbContextOptions<equiposContext> options): base(options) 
        {

        }

        public DbSet<marcas> marcas { get; set; }
        public DbSet<equipos> equipos { get; set; }
    }
}
