using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_farmacia_pf2.Model
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Tipo { get; set; } = string.Empty;

        
        [Column(TypeName = "BIT")]
        public Boolean IsValid { get; set; }

    }
}
