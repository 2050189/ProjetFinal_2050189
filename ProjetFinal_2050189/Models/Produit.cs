using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_2050189.Models
{
    [Table("Produit", Schema = "SOLDEJANEIRO")]
    public partial class Produit
    {
        public Produit()
        {
            Details = new HashSet<Detail>();
            Hydratants = new HashSet<Hydratant>();
            Savons = new HashSet<Savon>();
            Vaporisateurs = new HashSet<Vaporisateur>();
        }

        [Key]
        [Column("ProduitID")]
        public int ProduitId { get; set; }
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [StringLength(25)]
        public string Format { get; set; } = null!;
        [Column("GammeID")]
        public int GammeId { get; set; }

        [ForeignKey("GammeId")]
        [InverseProperty("Produits")]
        public virtual Gamme Gamme { get; set; } = null!;
        [InverseProperty("Produit")]
        public virtual ICollection<Detail> Details { get; set; }
        [InverseProperty("Produit")]
        public virtual ICollection<Hydratant> Hydratants { get; set; }
        [InverseProperty("Produit")]
        public virtual ICollection<Savon> Savons { get; set; }
        [InverseProperty("Produit")]
        public virtual ICollection<Vaporisateur> Vaporisateurs { get; set; }
    }
}
