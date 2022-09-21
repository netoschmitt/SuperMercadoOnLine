using Microsoft.EntityFrameworkCore;
using SuperMercadoNetoOnLine.Models;

namespace SuperMercadoNetoOnLine.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
