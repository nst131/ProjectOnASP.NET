namespace DomainYandexMusic.Entities
{
    public class UserImage
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public User User { get; set; }
    }
}
