using System.ComponentModel.DataAnnotations;

namespace Studio.Entities.DTOs.AppUserDtos
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
