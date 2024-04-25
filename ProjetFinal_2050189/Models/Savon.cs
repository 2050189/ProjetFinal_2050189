using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_2050189.Models
{
    [Table("Savon", Schema = "SOLDEJANEIRO")]
    public partial class Savon
    {
        [Key]
        [Column("SavonID")]
        public int SavonId { get; set; }
        [StringLength(10)]
        public string Texture { get; set; } = null!;
        [Column("ProduitID")]
        public int ProduitId { get; set; }

        [ForeignKey("ProduitId")]
        [InverseProperty("Savons")]
        public virtual Produit Produit { get; set; } = null!;
    }
}
