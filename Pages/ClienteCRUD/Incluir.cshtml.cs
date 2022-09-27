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

        [BindProperty]     // prop vinculada aos campos do formulario desta pagina (endereço, logradouro ... vem do CEP)
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
            cliente.Endereco = new Endereco(); // faço e endereço do cliente receber um novo endereço
            //novos clientes sempre iniciam com essa situação
            cliente.Situacao = Cliente.SituacaoCliente.Cadastrado; // indico que a situação do cliente é cadastrado.


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
