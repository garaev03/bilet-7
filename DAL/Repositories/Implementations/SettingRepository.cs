using Microsoft.EntityFrameworkCore;
using Studio.DAL.Repositories.Interfaces;
using Studio.Entities.Concrets;

namespace Studio.DAL.Repositories.Implementations
{
    public class SettingRepository : ISettingRepository
    {
        private readonly AppDbContext _db;
        public SettingRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Setting> Get()
        => await _db.Settings.FirstOrDefaultAsync();

        public string GetLogo()
        => _db.Settings.FirstOrDefault().Logo;

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
