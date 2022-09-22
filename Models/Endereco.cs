using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperMercadoNetoOnLine.Models
{
    [Owned]
    public class Endereco
    {
        [Required(ErrorMessage = "o CEP informado não retornou um endereço válido.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Logradouro { get; set; }


        [Required(ErrorMessage = "o Campo \"{0}\" é de preenchimento obrigatório.")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Complemento { get; set; }


        [Required(ErrorMessage = "o Campo \"{0}\" é de preenchimento obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "o Campo \"{0}\" é de preenchimento obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "o Campo \"{0}\" é de preenchimento obrigatório.")]
        [MaxLength(2, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "o Campo \"{0}\" é de preenchimento obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        [RegularExpression(@"[0-9]{8}$", ErrorMessage = "O campo \"{0}\" deve ser preenchido com um CEP válido")]
        [UIHint("_CepTemplate")]
        public string CEP { get; set; }


        [DisplayName("Referência")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Referencia { get; set; }
    }
}
