using System.Threading.Tasks;
using SuperMercadoNetoOnLine.Data;
using SuperMercadoNetoOnLine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting;

namespace SuperMercadoNetoOnLine.Pages.ProdutoCRUD
{
    public class IncluirModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]  //|1|
        public Produto Produto { get; set; }

        public string CaminhoImagem { get; set; }

        [BindProperty]
        [Display(Name = "Imagem do Produto")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public IFormFile ImagemProduto { get; set; }

        public IncluirModel(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            CaminhoImagem = "~/img/produto/sem_imagem.jpg";
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ImagemProduto == null)
            {
                return Page();
            }

            var produto = new Produto();
                                                   //|1|
            if(await TryUpdateModelAsync(produto, Produto.GetType(), nameof(Produto)))
            {
                _context.Produtos.Add(Produto);
                await _context.SaveChangesAsync();
                await AppUtils.ProcessarArquivoDeImagem(produto.IdProduto, ImagemProduto, _webHostEnvironment);
                return RedirectToPage("./Listar");
            }
            return Page();
        }
    }
}
