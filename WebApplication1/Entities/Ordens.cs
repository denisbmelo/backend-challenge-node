﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Ordens
    {
        public int IdTransacao { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public decimal ValorCompra { get; set; }
        public int QtdCompra { get; set; }
        public decimal TotalCompra { get; set; }
        public DateTime DtOrdem { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Produtos IdProdutoNavigation { get; set; }
    }
}