namespace DomainYandexMusic.Entities
{
    public class AlbumImage
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public Album Album { get; set; } 
    }
}
