using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMercadoNetoOnLine.Pages.ClienteCRUD
{
    public class AlterarModel : PageModel
    {
        [BindProperty]
        public Cliente Cliente { get; set; }

        private ApplicationDBContext _context;

        // este obj instancia o db
        public AlterarModel(ApplicationDBContext context)
        {
            _context=context;
        }
        // processa os dados para mandar a pagina para o usuario que acabou de requisitar, se id é nulo..., se não for..., 
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            // tenta encontra um cliente com este id, se sim, devolve a pag com o obj
            Cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.IdCliente == id);
            if(Cliente == null)
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
            // reassocio o cliente ao db e seto estado modificado(alterado)
            _context.Attach(Cliente).State = EntityState.Modified;

            try
            {       // tento salvar as alteraçoes
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteAindaExiste(Cliente.IdCliente))
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
        private bool ClienteAindaExiste(int id)
        {
            return _context.Clientes.Any(m => m.IdCliente == id);
        }
    }
}
