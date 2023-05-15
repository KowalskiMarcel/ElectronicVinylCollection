namespace ElectronicVinylCollection.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual List<Media> Medias { get; set; }


    }
}
