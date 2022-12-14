using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMercadoNetoOnLine.Models
{
    public class Pedido
    {
        public enum SituacaoPedido
        {
            Cancelado,
            Realizado,
            Verificado,
            Atendido,
            Entregue
        }

        [Key]
        [Display(Name ="Código")]
        public int IdPedido { get; set; }

        
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [Display(Name ="Data/Hora")]
        public DateTime DataHoraPedido { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [Column(TypeName ="decimal(18,2)")]
        [Display(Name = "Valor Total")]
        public decimal Valortotal { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [Display(Name = "Situação")]
        public SituacaoPedido Situacao { get; set; }

        [ForeignKey("IdCliente")]
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }

        public Endereco Endereco { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
    }
}
