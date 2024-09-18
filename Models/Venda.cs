using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria03.Models
{
    public class Venda
    {
        [Key]
        [Column("IdVenda")]
        public int Id { get; set; }

        [Required]
        [Column("IdCliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        [Column("IdProduto")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required]
        [Column("ValorTotal")]
        public decimal ValorTotal { get; set; }

        [NotMapped]
        public int Quantidade { get; set; }

        [NotMapped]
        public decimal ValorUnitario { get; set; }
    }
}
