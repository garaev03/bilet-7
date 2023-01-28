using Studio.Entities.Concrets;
using Studio.Entities.DTOs.TeamMemberDtos;

namespace Studio.Business.Utilities.Profile
{
    public class Mapper: AutoMapper.Profile
    {
        public Mapper()
        {
            CreateMap<TeamMember, TeamMemberGetDto>();
            CreateMap<TeamMemberPostDto, TeamMember>();
        }
    }
}
