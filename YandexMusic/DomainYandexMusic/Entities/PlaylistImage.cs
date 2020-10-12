namespace DomainYandexMusic.Entities
{
    public class PlaylistImage
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public Playlist Playlist { get; set; }
    }
}
