using ProjetFinal_2050189.Models;

namespace ProjetFinal_2050189.ViewModels
{
    public class MagasinInfoVM
    {
        public Magasin Magasin { get; set; }
        public IEnumerable<VwMagasinVenteInfo> Infos { get; set; }

        //public IEnumerable<int> MontantVente { get; set; }

        public MagasinInfoVM() 
        {
            
        }
    }
}
