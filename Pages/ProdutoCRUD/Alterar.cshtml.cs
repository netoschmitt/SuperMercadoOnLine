using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMercadoNetoOnLine.Pages.ProdutoCRUD
{
    public class AlterarModel : PageModel
    {
        [BindProperty]
        public Produto Produto { get; set; }

        private ApplicationDBContext _context;

        // este obj instancia o db
        public AlterarModel(ApplicationDBContext context)
        {
            _context = context;
        }
        // processa os dados para mandar a pagina para o usuario que acabou de requisitar, se id é nulo..., se não for..., 
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            // tenta encontra um produto com este id, se sim, devolve a pag com o obj
            Produto = await _context.Produtos.FirstOrDefaultAsync(m => m.IdProduto == id);
            if(Produto == null)
            {
                return NotFound();
            }
            return Page();
        }
        // 
        public async Task<IActionResult> OnPostAsync()
        {   // se o meu modelo é valido
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // reassocio o Produto ao db e seto estado modificado(alterado)
            _context.Attach(Produto).State = EntityState.Modified;

            try
            {       // tento salvar as alteraçoes
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(Produto.IdProduto))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Listar");
        }
        // Any return true se encontrar um obj q satisfaça esta condição/ IdCliente = id passado
        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.IdProduto == id);
        }
    }
}
