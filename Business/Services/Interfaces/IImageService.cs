namespace Studio.Business.Services.Interfaces
{
    public interface IImageService
    {
        void CheckType(IFormFile file);
        void CheckSize(IFormFile file, double size);
        Task<string> CreateImageAsync(string Rootpath,string Folderpath,IFormFile file);
    }
}
