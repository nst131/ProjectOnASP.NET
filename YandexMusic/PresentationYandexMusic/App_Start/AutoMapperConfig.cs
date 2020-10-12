using AutoMapper;
using DomainYandexMusic.Entities;
using PresentationYandexMusic.Areas.Admin.ViewModel;

namespace PresentationYandexMusic.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            //--------------------------------- Track ---------------------------------------
            cfg.CreateMap<TrackViewModel, TrackImage>()
                .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.TrackImage.ContentLength]))
                .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.TrackImage.ContentType));

            cfg.CreateMap<TrackViewModel, TrackFile>();

            cfg.CreateMap<TrackViewModel, Track>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.TrackName))
                .ForMember(x => x.TimeOfCreation, y => y.MapFrom(z => z.TimeOfCreation))
                .ForMember(x => x.Liked, y => y.MapFrom(z => z.Liked))

                .ForMember(x => x.TrackImage, y => y.MapFrom(z => Mapper.Map<TrackViewModel, TrackImage>(z)))
                .ForMember(x => x.TrackFile, y => y.MapFrom(z => Mapper.Map<TrackViewModel, TrackFile>(z)));

            // --------------------------------- Genre -------------------------------------
            cfg.CreateMap<GenreViewModel, GenreImage>()
                .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.GenreImage.ContentLength]))
                .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.GenreImage.ContentType));

            cfg.CreateMap<GenreViewModel, Genre>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.GenreName))
                .ForMember(x => x.GenreImage, y => y.MapFrom(z => Mapper.Map<GenreViewModel, GenreImage>(z)));

            //--------------------------------- Singer ---------------------------------------
            cfg.CreateMap<SingerViewModel, SingerImage>()
                .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.SingerImage.ContentLength]))
                .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.SingerImage.ContentType));

            cfg.CreateMap<SingerViewModel, Singer>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.SingerName))
                .ForMember(x => x.SingerImage, y => y.MapFrom(z => Mapper.Map<SingerViewModel, SingerImage>(z)));

            //----------------------------------- Album ---------------------------------------
            cfg.CreateMap<AlbumViewModel, AlbumImage>()
               .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.AlbumImage.ContentLength]))
               .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.AlbumImage.ContentType));

            cfg.CreateMap<AlbumViewModel, Album>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.AlbumName))
                .ForMember(x => x.AlbumImage, y => y.MapFrom(z => Mapper.Map<AlbumViewModel, AlbumImage>(z)));

            //--------------------------------- Playlist ---------------------------------------
            cfg.CreateMap<PlaylistViewModel, PlaylistImage>()
               .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.PlaylistImage.ContentLength]))
               .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.PlaylistImage.ContentType));

            cfg.CreateMap<PlaylistViewModel, Playlist>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.PlaylistName))
                .ForMember(x => x.PlaylistImage, y => y.MapFrom(z => Mapper.Map<PlaylistViewModel, PlaylistImage>(z)));
        }
    }
}