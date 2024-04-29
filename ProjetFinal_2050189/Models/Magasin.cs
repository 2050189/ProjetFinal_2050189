using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_2050189.Models
{
    [Table("Magasin", Schema = "VENTE")]
    public partial class Magasin
    {
        public Magasin()
        {
            Achats = new HashSet<Achat>();
        }

        [Key]
        [Column("MagasinID")]
        public int MagasinId { get; set; }
        [StringLength(25)]
        public string Nom { get; set; } = null!;
        [Column("AProgrammePts")]
        public bool AprogrammePts { get; set; }

        [InverseProperty("Magasin")]
        public virtual ICollection<Achat> Achats { get; set; }
    }
}
