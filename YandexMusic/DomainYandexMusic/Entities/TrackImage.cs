namespace DomainYandexMusic.Entities
{
    public class TrackImage
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public Track Track { get; set; } 
    }
}
