using AutoMapper;
using Studio.Business.Services.Interfaces;
using Studio.DAL.Repositories.Interfaces;
using Studio.Entities.Concrets;
using Studio.Entities.DTOs.TeamMemberDtos;

namespace Studio.Business.Services.Implementations
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _repository;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public TeamMemberService(ITeamMemberRepository repository, IMapper mapper, IImageService imageService, IWebHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
            _env = env;
        }

        public async Task<List<TeamMemberGetDto>> GetAllAsync()
        => _mapper.Map<List<TeamMemberGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<TeamMemberGetDto> GetByIdAsync(int id)
        {
            TeamMemberGetDto member = _mapper.Map<TeamMemberGetDto>(await _repository.GetByIdAsync(id));
            if (member is null)
                throw new Exception("Team Member Not Found!");
            return member;
        }

        public async Task CreateAsync(TeamMemberPostDto postDto)
        {
            if (postDto.formFile is null)
                throw new Exception("Image can't be null!");
            _imageService.CheckType(postDto.formFile);
            _imageService.CheckSize(postDto.formFile, 2);
            string ImageName = await _imageService.CreateImageAsync(_env.WebRootPath, "assets/img/", postDto.formFile);
            TeamMember member = _mapper.Map<TeamMember>(postDto);
            member.Image = ImageName;
            await _repository.CreateAsync(member);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TeamMember member = await _repository.GetByIdAsync(id);
            if (member is null)
                throw new Exception("Member not found!");
            _repository.Delete(member);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(TeamMemberUpdateDto updateDto)
        {
            TeamMember member = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (member is null)
                throw new Exception("Member not found!");
            if (updateDto.postDto.formFile is not null)
            {
                _imageService.CheckType(updateDto.postDto.formFile);
                _imageService.CheckSize(updateDto.postDto.formFile, 2);
                string ImageName = await _imageService.CreateImageAsync(_env.WebRootPath, "assets/img/", updateDto.postDto.formFile);
                member.Image = ImageName;
            }
            member.Name = updateDto.postDto.Name;
            member.Position = updateDto.postDto.Position;
            member.FacebookLink = updateDto.postDto.FacebookLink;
            member.LinkedinLink = updateDto.postDto.LinkedinLink;
            member.TwitterLink = updateDto.postDto.TwitterLink;
            await _repository.SaveAsync();
        }
    }
}
