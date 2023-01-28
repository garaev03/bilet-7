
using Studio.Core.Repositories.Implementations;
using Studio.DAL.Repositories.Interfaces;
using Studio.Entities.Concrets;

namespace Studio.DAL.Repositories.Implementations
{
    public class TeamMemberRepository : TEntityRepository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(AppDbContext db) : base(db)       {       }

        public void Delete(TeamMember teamMember)
        {
            teamMember.isDeleted = true;
        }
    }
}
