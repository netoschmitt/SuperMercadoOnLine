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
        private readonly ApplicationDBContext _context;
        
        public AlterarModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

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
        
        public async Task<IActionResult> OnPostAsync()
        {
            //para garantir que o cpf e o e-mail não serão atualizados
            var cliente = await _context.Clientes.Select(m => new { m.IdCliente, m.Email, m.CPF }).FirstOrDefaultAsync();
            Cliente.Email = cliente.Email;
            Cliente.CPF = cliente.CPF;

            //ModelState.ClearValidationState("Cliente.Email");
            //ModelState.ClearValidationState("Cliente.CPF");

            if (ModelState.Keys.Contains("Cliente.Email"))
            {
                ModelState["Cliente.Email"].Errors.Clear();
                ModelState.Remove("Cliente.Email");
            }
            if (ModelState.Keys.Contains(Cliente.CPF))
            {
                ModelState["Cliente.CPF"].Errors.Clear();
                ModelState.Remove("Cliente.CPF");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            // reassocio o cliente ao db e seto estado modificado(alterado)
            _context.Attach(Cliente).State = EntityState.Modified;
            _context.Attach(Cliente.Endereco).State = EntityState.Modified;

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
