using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_2050189.Models
{
    [Table("Achat", Schema = "VENTE")]
    public partial class Achat
    {
        public Achat()
        {
            Details = new HashSet<Detail>();
        }

        [Key]
        [Column("AchatID")]
        public int AchatId { get; set; }
        [Column(TypeName = "money")]
        public decimal MontantTotal { get; set; }
        [Column("MagasinID")]
        public int MagasinId { get; set; }

        [ForeignKey("MagasinId")]
        [InverseProperty("Achats")]
        public virtual Magasin Magasin { get; set; } = null!;
        [InverseProperty("Achat")]
        public virtual ICollection<Detail> Details { get; set; }
    }
}
