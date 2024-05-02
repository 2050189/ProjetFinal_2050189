using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_2050189.Models
{
    [Keyless]
    [Table("ClientDechiffre", Schema = "VENTE")]
    public partial class ClientDechiffre
    {
        [StringLength(10)]
        public string NumeroTel { get; set; } = null!;
    }
}
