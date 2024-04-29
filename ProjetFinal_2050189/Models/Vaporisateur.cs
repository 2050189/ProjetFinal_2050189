using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_2050189.Models
{
    [Table("Vaporisateur", Schema = "SOLDEJANEIRO")]
    public partial class Vaporisateur
    {
        [Key]
        [Column("VaporisateurID")]
        public int VaporisateurId { get; set; }
        [StringLength(10)]
        public string Intensite { get; set; } = null!;
        [Column("ProduitID")]
        public int ProduitId { get; set; }

        [ForeignKey("ProduitId")]
        [InverseProperty("Vaporisateurs")]
        public virtual Produit Produit { get; set; } = null!;
    }
}
