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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPedido>()
                .HasKey(e => new { e.IdPedido, e.IdProduto });

            modelBuilder.Entity<Favorito>()
                .HasKey(e => new { e.IdCliente, e.IdProduto });

            modelBuilder.Entity<Visitado>()
                .HasKey(e => new { e.IdCliente, e.IdProduto });
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
    }
}
