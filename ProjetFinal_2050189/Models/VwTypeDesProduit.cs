using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_2050189.Models
{
    [Keyless]
    public partial class VwTypeDesProduit
    {
        [Column("ProduitID")]
        public int ProduitId { get; set; }
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [Column("Type de produit")]
        [StringLength(12)]
        [Unicode(false)]
        public string TypeDeProduit { get; set; } = null!;
    }
}
