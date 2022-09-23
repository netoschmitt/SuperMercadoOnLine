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

        // PK compostas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPedido>()
                .HasKey(e => new { e.IdPedido, e.IdProduto });

            modelBuilder.Entity<Favorito>()
                .HasKey(e => new { e.IdCliente, e.IdProduto });

            modelBuilder.Entity<Visitado>()
                .HasKey(e => new { e.IdCliente, e.IdProduto });
        }

        // coleções de dados
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Visitado> Visitados { get; set; }
    }
}
