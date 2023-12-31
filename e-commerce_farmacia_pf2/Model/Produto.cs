﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_farmacia_pf2.Model
{
    public class Produto
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string Nome { get; set; } = string.Empty;


        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string Descricao { get; set; } = string.Empty;


        [Column(TypeName = "Decimal (6,2) ")]
        public decimal Preco { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(5000)]
        public string Foto { get; set; } = string.Empty;

        
        [Column(TypeName = "Varchar")]
        [StringLength(5000)]
        public string Quantidade { get; set; } = string.Empty;


    }
}
