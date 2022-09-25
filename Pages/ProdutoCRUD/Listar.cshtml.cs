using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;





namespace SuperMercadoNetoOnLine.Pages.ProdutoCRUD
{
    public class ListarModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public ListarModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get; set; }

        public async Task OnGetAsync()
        {
            Produto = await _context.Produtos.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produto = await _context.Produtos.FindAsync(id);

            if(Produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Listar");
        }
    }
}
