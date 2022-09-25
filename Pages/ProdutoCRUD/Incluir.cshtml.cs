using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;
using System.Threading.Tasks;

namespace SuperMercadoNetoOnLine.Pages.ProdutoCRUD
{
    public class IncluirModel : PageModel
    {
        private ApplicationDBContext _context;

        [BindProperty]     // prop vinculada aos campos do formulario desta pagina
        public Produto Produto { get; set; }

        public IncluirModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var produto = new Produto();
            if(await TryUpdateModelAsync<Produto>(produto, "produto",
                obj => obj.Nome, obj => obj.Descricao, obj => obj.Preco , obj => obj.Estoque))
            {
                _context.Produtos.Add(Produto);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Listar");
            }
            return Page();
        }
    }
}
