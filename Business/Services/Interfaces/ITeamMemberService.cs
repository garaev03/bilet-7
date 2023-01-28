using Studio.Entities.DTOs.TeamMemberDtos;

namespace Studio.Business.Services.Interfaces
{
    public interface ITeamMemberService
    {
        Task<List<TeamMemberGetDto>> GetAllAsync();
        Task<TeamMemberGetDto> GetByIdAsync(int id);
        Task CreateAsync(TeamMemberPostDto postDto);
        Task UpdateAsync(TeamMemberUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
