using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;
using System.Threading.Tasks;

namespace SuperMercadoNetoOnLine.Pages.ClienteCRUD
{
    public class IncluirModel : PageModel
    {
        private ApplicationDBContext _context;

        [BindProperty]     // prop vinculada aos campos do formulario desta pagina
        public Cliente Cliente { get; set; }

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
            var cliente = new Cliente();
            if(await TryUpdateModelAsync<Cliente>(cliente, "cliente",
                obj => obj.Nome, obj => obj.DataNascimento, obj => obj.Email, obj => obj.CPF))
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Listar");
            }
            return Page();
        }
    }
}
