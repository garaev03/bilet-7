using Studio.Entities.Concrets;

namespace Studio.DAL.Repositories.Interfaces
{
    public interface ISettingRepository
    {
        string GetLogo();
        Task<Setting> Get();
        Task SaveAsync();
    }
}
