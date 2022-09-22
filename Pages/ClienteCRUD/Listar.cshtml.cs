using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperMercadoNetoOnLine.Pages.ClienteCRUD
{
    public class ListarModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public IList<Cliente> Clientes { get; set; } 

        public ListarModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
        }
    }
}
