﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMercadoNetoOnLine.Models
{
    public class Favorito
    {
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IDProduto { get; set; }
        [Required]
        public DateTime DataHora { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

    }
}
