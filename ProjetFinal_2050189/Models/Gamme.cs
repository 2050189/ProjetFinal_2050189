using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_2050189.Models
{
    [Table("Gamme", Schema = "SOLDEJANEIRO")]
    [Index("Nom", Name = "UC_Gamme_Nom", IsUnique = true)]
    public partial class Gamme
    {
        public Gamme()
        {
            Produits = new HashSet<Produit>();
        }

        [Key]
        [Column("GammeID")]
        public int GammeId { get; set; }
        [StringLength(25)]
        public string Nom { get; set; } = null!;
        public int AnneeSortie { get; set; }
        public int Cote { get; set; }
        [StringLength(25)]
        public string Note1 { get; set; } = null!;
        [StringLength(25)]
        public string Note2 { get; set; } = null!;
        [StringLength(25)]
        public string Note3 { get; set; } = null!;
        [StringLength(25)]
        public string Couleur { get; set; } = null!;

        [InverseProperty("Gamme")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
