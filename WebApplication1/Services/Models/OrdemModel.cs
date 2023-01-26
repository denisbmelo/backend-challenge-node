namespace WebApplication1.Services.Models
{
    public class OrdemModel
    {
        public int idCliente { get; set; }
        public int idProduto { get; set; }
        public decimal valorCompra { get; set; }
        public int qtdCompra { get; set; }
        public decimal totalCompra { get; set; }
        public DateTime dtOrdem { get; set; }
    }
}
