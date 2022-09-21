using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<SuperMercadoNetoOnLine.Models.Produto> Produto { get; set; }
    }
}
