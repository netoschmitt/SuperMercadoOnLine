using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;

namespace SuperMercadoNetoOnLine.Pages.ProdutoCRUD
{
    public class IndexModel : PageModel
    {
        private readonly SuperMercadoNetoOnLine.Data.ApplicationDBContext _context;

        public IndexModel(SuperMercadoNetoOnLine.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; }

        public async Task OnGetAsync()
        {
            Produto = await _context.Produto.ToListAsync();
        }
    }
}
