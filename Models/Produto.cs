using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LojaWEB_EF.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProduto { get; set; }

        [Required(ErrorMessage="Campo nome não pode ficar nulo")]
        [StringLength(70,MinimumLength=2)]
        public string nomeProduto { get; set; }

        [Required(ErrorMessage="Campo descrição não pode ficar nulo")]
        [DataType(DataType.Text)]
        public string descricao { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal preco{ get; set; }

        public int quantidade { get; set; }
       
        public ICollection<Pedido> pedido { get; set; }

    }
}