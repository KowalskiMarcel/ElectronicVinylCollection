using System.ComponentModel.DataAnnotations;

namespace ElectronicVinylCollection.Models
{
    public class ModificateUserDto
    {
        [MaxLength(25)]
        public string NickName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
