using System.ComponentModel.DataAnnotations;

namespace ElectronicVinylCollection.Models
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(25)]
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
