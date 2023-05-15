namespace ElectronicVinylCollection.Entities
{
    public class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Artist { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } 
    }
}
