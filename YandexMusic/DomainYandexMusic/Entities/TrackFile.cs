namespace DomainYandexMusic.Entities
{
    public class TrackFile
    {
        public int Id { get; set; }

        public string FileLocation { get; set; }

        public Track Track { get; set; } 
    }
}
