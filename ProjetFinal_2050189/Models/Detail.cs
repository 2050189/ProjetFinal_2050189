using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_2050189.Models
{
    [Table("Details", Schema = "VENTE")]
    public partial class Detail
    {
        [Key]
        [Column("DetailsID")]
        public int DetailsId { get; set; }
        [Column(TypeName = "money")]
        public decimal PrixPaye { get; set; }
        [Column("AchatID")]
        public int AchatId { get; set; }
        [Column("ProduitID")]
        public int ProduitId { get; set; }

        [ForeignKey("AchatId")]
        [InverseProperty("Details")]
        public virtual Achat Achat { get; set; } = null!;
        [ForeignKey("ProduitId")]
        [InverseProperty("Details")]
        public virtual Produit Produit { get; set; } = null!;
    }
}
