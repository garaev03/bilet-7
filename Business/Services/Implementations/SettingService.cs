using NuGet.Packaging;
using Studio.Business.Services.Interfaces;
using Studio.DAL.Repositories.Interfaces;
using Studio.Entities.Concrets;

namespace Studio.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _repository;
        public SettingService(ISettingRepository repository)
        {
            _repository = repository;
        }

        public Task<Setting> Get()
       => _repository.Get();

        public string GetLogo()
        => _repository.GetLogo();


        public async Task Update(Setting NewSetting)
        {
            Setting setting = await _repository.Get();
            setting.Logo = NewSetting.Logo;
            setting.FacebookLink = NewSetting.FacebookLink;
            setting.LinkedinLink = NewSetting.LinkedinLink;
            setting.TwitterLink = NewSetting.TwitterLink;
            await _repository.SaveAsync();
        }
    }
}
