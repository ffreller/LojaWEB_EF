using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LojaWEB_EF.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCliente { get; set; }

        [Required(ErrorMessage="Campo nome não pode ficar nulo")]
        [StringLength(70,MinimumLength=2)]
        public string nomeCliente { get; set; }

        [Required(ErrorMessage="Campo email não pode ficar nulo")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage="Campo idade não pode ficar nulo")]
        [Range(1,100)]
        public int idade { get; set; }
       
        public ICollection<Pedido> pedido { get; set; }

    }
}