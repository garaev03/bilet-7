namespace Studio.Entities.Concrets
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string TwitterLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedinLink { get; set; }
        public bool isDeleted { get; set; }
    }
}
