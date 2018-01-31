using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LojaWEB_EF.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPedido { get; set; }
        [Required]
        public int idProduto { get; set; }
        [Required]
        public int idCliente { get; set; }
        [Required]
        public int quantidade { get; set; }
        public Produto produto { get; set; }
        public Cliente cliente { get; set; }
    }
}