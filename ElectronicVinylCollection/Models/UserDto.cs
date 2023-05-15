using ElectronicVinylCollection.Entities;

namespace ElectronicVinylCollection.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public virtual List<MediaDto> Medias { get; set; }
    }
}
