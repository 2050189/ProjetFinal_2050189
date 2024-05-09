using ProjetFinal_2050189.Models;

namespace ProjetFinal_2050189.ViewModels
{
    public class UploadPhotoGammeVM
    {
        public int GammeID { get; set; }

        public IFormFile? FormFile { get; set; }

        public UploadPhotoGammeVM()
        {
            
        }
    }
}
