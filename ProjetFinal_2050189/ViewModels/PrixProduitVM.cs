namespace ProjetFinal_2050189.ViewModels
{
    public class PrixProduitVM
    {
        public string Nom { get; set; } = null!;
        public string Format { get; set; } = null!;

        public List<decimal>? Prix { get; set; }
    }
}
