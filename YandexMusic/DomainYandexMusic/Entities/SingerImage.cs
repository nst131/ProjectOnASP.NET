namespace DomainYandexMusic.Entities
{
    public class SingerImage
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public Singer Singer { get; set; } 
    }
}
