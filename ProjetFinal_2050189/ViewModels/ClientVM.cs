using ProjetFinal_2050189.Models;

namespace ProjetFinal_2050189.ViewModels
{
    public class ClientVM
    {
        public Client Client { get; set; } = null!;
        public ClientDechiffre Dechiffre { get; set; } = null!;

        public ClientVM()
        {
            
        }
    }
}
