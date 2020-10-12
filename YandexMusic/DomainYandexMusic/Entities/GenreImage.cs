namespace DomainYandexMusic.Entities
{
    public class GenreImage
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public Genre Genre { get; set; }
    }
}
