using System.Web;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using FluentValidation;
using PresentationYandexMusic.Areas.Admin.ViewModel.Track;

namespace PresentationYandexMusic.Areas.Admin.Validation.Track
{
    public class AdminValidationOfTrackCreate : AbstractValidator<CreateTrackViewModel>
    {
        private readonly ITrackDomainService trackDomain;
        private readonly ISingerDomainService singerDomain;
        private readonly IAlbumDomainService albumDomain;
        private readonly IGenreDomainService genreDomain;

        public AdminValidationOfTrackCreate(
            ITrackDomainService trackDomain,
            ISingerDomainService singerDomain,
            IAlbumDomainService albumDomain,
            IGenreDomainService genreDomain)
        {
            this.trackDomain = trackDomain;
            this.singerDomain = singerDomain;
            this.albumDomain = albumDomain;
            this.genreDomain = genreDomain;

            RuleFor(x => x.TrackName)
                .NotEmpty().WithMessage("Введитете имя альбома")
                .MaximumLength(50).WithMessage("Альбом не может превысить 50 символов")
                .Must(CreateTrackIsUnique).WithMessage("Трек с таким именем уже существует");

            RuleFor(x => x.TimeOfCreation)
                .NotEmpty().WithMessage("Введите дату создания")
                .GreaterThan(new System.DateTime(2000, 1, 1)).WithMessage("Дата не раньше 2000 года");

            RuleFor(x => x.NumberOfLikes)
                .NotEmpty().WithMessage("Введите кол-во лайков больше 0")
                .GreaterThanOrEqualTo(-1).WithMessage("Лайки не могут быть отрицательными");

            RuleFor(x => x.SingerId)
                .Must(IsExistSinger).WithMessage("Такого исполнителя не существует");

            RuleFor(x => x.AlbumId)
                .Must(IsExistAlbum).WithMessage("Такого альбома не существует");

            RuleFor(x => x.GenreId)
                .Must(IsExistGenre).WithMessage("Такого жанра не существует");

            RuleFor(x => x.PopularId)
                .NotEmpty().WithMessage("Поле Популярное обязательное для заполнение");

            RuleFor(x => x.NoveltyId)
                .NotEmpty().WithMessage("Поле Новинки обязательное для заполнение");

            RuleFor(x => x.TrackImage)
                .NotEmpty().WithMessage("Картинка не выбрана")
                .Must(IsJpg).WithMessage("Картинка должна иметь тип jpg");

            RuleFor(x => x.TrackFile)
                .NotEmpty().WithMessage("Файл не выбран")
                .Must(IsMP3).WithMessage("Файл должен иметь тип mp3");
        }

        public bool CreateTrackIsUnique(string trackName)
        {
            return trackDomain.CreateTrackIsUnique(trackName);
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return trackDomain.IsJpg(file);
        }

        public bool IsMP3(HttpPostedFileBase file)
        {
            return trackDomain.IsMP3(file);
        }

        public bool IsExistSinger(int id)
        {
            return singerDomain.IsExistSinger(id);
        }

        public bool IsExistAlbum(int id)
        {
            return albumDomain.IsExistAlbum(id);
        }

        public bool IsExistGenre(int id)
        {
            return genreDomain.IsExistAlbum(id);
        }
    }
}