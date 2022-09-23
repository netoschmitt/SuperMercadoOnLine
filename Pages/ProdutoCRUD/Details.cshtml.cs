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
    public class DetailsModel : PageModel
    {
        private readonly SuperMercadoNetoOnLine.Data.ApplicationDBContext _context;

        public DetailsModel(SuperMercadoNetoOnLine.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public Produto Produto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto = await _context.Produtos.FirstOrDefaultAsync(m => m.IdProduto == id);

            if (Produto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
