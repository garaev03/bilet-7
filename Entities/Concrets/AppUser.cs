using Microsoft.AspNetCore.Identity;

namespace Studio.Entities.Concrets
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
    }
}
