using System.ComponentModel.DataAnnotations;

namespace ProjetFinal_2050189.ViewModels
{
    public class InsertClientVM
    {
        public string Prenom { get; set; } = null!;

        public string NumeroTel { get; set; } = null!;

        public InsertClientVM()
        {
            
        }
    }
}
