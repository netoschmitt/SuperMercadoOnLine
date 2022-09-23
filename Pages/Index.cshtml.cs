using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMercadoNetoOnLine.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private ApplicationDBContext _context;

        //propriedade produtos acessada pela Model no foreach
        public IList<Produto> Produtos;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        // metodo retorna uma tarefa/retorna os produtos do db / desmenbrado em 2 , uma thread, e outro.. espera termino desta execução para retornar o conteudo p page
        public async Task OnGetAsync()
        {
            Produtos = await _context.Produtos.ToListAsync<Produto>();
        }
                
    }
}
