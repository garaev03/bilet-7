using Studio.Business.Services.Interfaces;
using System.Drawing;

namespace Studio.Business.Services.Implementations
{
    public class ImageService : IImageService
    {
        public void CheckSize(IFormFile file,double size)
        {
            if (file.Length / 1024 / 1024 >= size)
                throw new Exception($"Image size can't be larger than {size}MB!");
        }

        public void CheckType(IFormFile file)
        {
            if (!file.ContentType.Contains("image"))
                throw new Exception("File is not image!");
        }

        public async Task<string> CreateImageAsync(string Rootpath, string Folderpath, IFormFile file)
        {
            string FileName = Guid.NewGuid() + "-" + file.FileName;
            string FullPath = Rootpath + "/" + Folderpath + FileName;
            using (FileStream stream= new(FullPath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return FileName;
        }
    }
}
