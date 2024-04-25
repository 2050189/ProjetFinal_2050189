using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_2050189.Models
{
    [Table("Hydratant", Schema = "SOLDEJANEIRO")]
    public partial class Hydratant
    {
        [Key]
        [Column("HydratantID")]
        public int HydratantId { get; set; }
        [StringLength(10)]
        public string Epaisseur { get; set; } = null!;
        [Column("ProduitID")]
        public int ProduitId { get; set; }

        [ForeignKey("ProduitId")]
        [InverseProperty("Hydratants")]
        public virtual Produit Produit { get; set; } = null!;
    }
}
