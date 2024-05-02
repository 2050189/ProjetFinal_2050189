using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_2050189.Models
{
    [Table("Client", Schema = "VENTE")]
    public partial class Client
    {
        [Key]
        [Column("ClientID")]
        public int ClientId { get; set; }
        [StringLength(15)]
        public string Prenom { get; set; } = null!;
        public byte[] NumeroTel { get; set; } = null!;
    }
}
