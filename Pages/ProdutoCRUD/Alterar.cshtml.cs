using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMercadoNetoOnLine.Pages.ProdutoCRUD
{
    public class AlterarModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public Produto Produto { get; set; }
        public string CaminhoImagem { get; set; }

        [BindProperty]
        [Display(Name = "Imagem do Produto")]

        public IFormFile ImagemProduto { get; set; }

        public AlterarModel(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            Produto = await _context.Produtos.FirstOrDefaultAsync(m => m.IdProduto == id);

            if(Produto == null)
            {
                return NotFound();
            }
                                            //cod produto com 6 digitos
            CaminhoImagem = $"~/img/produto/{Produto.IdProduto:D6}.jpg";

            return Page();
        }
         
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
