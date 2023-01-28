namespace Studio.Entities.DTOs.TeamMemberDtos
{
    public class TeamMemberPostDto
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string TwitterLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedinLink { get; set; }
        public IFormFile? formFile { get; set; }
    }
}
