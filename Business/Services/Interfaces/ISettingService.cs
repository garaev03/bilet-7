using Studio.Entities.Concrets;


namespace Studio.Business.Services.Interfaces
{
    public interface ISettingService
    {
        string GetLogo();
        Task<Setting> Get();
        Task Update(Setting setting);
    }
}
