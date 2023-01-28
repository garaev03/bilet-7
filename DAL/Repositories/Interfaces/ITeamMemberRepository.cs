using Studio.Core.Repositories.Interfaces;
using Studio.Entities.Concrets;

namespace Studio.DAL.Repositories.Interfaces
{
    public interface ITeamMemberRepository: ITEntityRepository<TeamMember>
    {
        void Delete(TeamMember teamMember);
    }
}
