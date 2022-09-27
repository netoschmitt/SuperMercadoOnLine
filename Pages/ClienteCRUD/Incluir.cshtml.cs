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

        [BindProperty]     // prop vinculada aos campos do formulario desta pagina (endere�o, logradouro ... vem do CEP)
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
            // crio um novo objeto cliente
            var cliente = new Cliente();
            cliente.Endereco = new Endereco(); // fa�o e endere�o do cliente receber um novo endere�o
            //novos clientes sempre iniciam com essa situa��o
            cliente.Situacao = Cliente.SituacaoCliente.Cadastrado; // indico que a situa��o do cliente � cadastrado.


            if (await TryUpdateModelAsync(cliente, Cliente.GetType(), nameof(Cliente)))
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Listar");
            }
            return Page();
        }
    }
}
