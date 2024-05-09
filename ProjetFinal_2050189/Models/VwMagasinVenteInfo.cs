using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_2050189.Models
{
    [Keyless]
    public partial class VwMagasinVenteInfo
    {
        [Column("MagasinID")]
        public int MagasinId { get; set; }
        [Column("Nom magasin")]
        [StringLength(25)]
        public string NomMagasin { get; set; } = null!;
        [Column("ProduitID")]
        public int ProduitId { get; set; }
        [Column("Nom produit")]
        [StringLength(50)]
        public string NomProduit { get; set; } = null!;
        [Column("Nombre Vendu")]
        public int? NombreVendu { get; set; }
    }
}
