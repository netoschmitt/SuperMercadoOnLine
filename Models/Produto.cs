using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMercadoNetoOnLine.Models
{
    public class Produto
    {
        [Key]
        [Display(Name = "Código")]
        [DisplayFormat(DataFormatString = "{0:D6}")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "O Campo \"{0}\" é de preenchimento obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo \"{0}\" pode ter até {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo \"{0}\"  é de preenchimento obrigatório.")]
        [MaxLength(1000, ErrorMessage = "O campo \"{0}\" pode ter até {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo \"{0}\"  é de preenchimento obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "O Campo \"{0}\"  é de preenchimento obrigatório.")]
        public int? Estoque { get; set; }

    }
}
