using AutoMapper;
using DomainYandexMusic.Entities;
using PresentationYandexMusic.Areas.Admin.ViewModel.Album;
using PresentationYandexMusic.Areas.Admin.ViewModel.Genre;
using PresentationYandexMusic.Areas.Admin.ViewModel.Playlist;
using PresentationYandexMusic.Areas.Admin.ViewModel.Singer;
using PresentationYandexMusic.Areas.Admin.ViewModel.Track;
using PresentationYandexMusic.Models;
using PresentationYandexMusic.Models.AlbumModels;

namespace PresentationYandexMusic.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            //--------------------------------- Track ---------------------------------------

            cfg.CreateMap<CreateTrackViewModel, TrackImage>()
                .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.TrackImage.ContentLength]))
                .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.TrackImage.ContentType));

            cfg.CreateMap<CreateTrackViewModel, TrackFile>();

            cfg.CreateMap<CreateTrackViewModel, Track>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.TrackName))
                .ForMember(x => x.TrackImage, y => y.MapFrom(z => Mapper.Map<CreateTrackViewModel, TrackImage>(z)))
                .ForMember(x => x.TrackFile, y => y.MapFrom(z => Mapper.Map<CreateTrackViewModel, TrackFile>(z)));

            cfg.CreateMap<EditTrackViewModel, Track>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.TrackName))
                .ForMember(x => x.TrackImage, y => y.Ignore())
                .ForMember(x => x.TrackFile, y => y.Ignore());

            // --------------------------------- Genre -------------------------------------

            cfg.CreateMap<CreateGenreViewModel, GenreImage>()
                .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.GenreImage.ContentLength]))
                .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.GenreImage.ContentType));

            cfg.CreateMap<CreateGenreViewModel, Genre>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.GenreName))
                .ForMember(x => x.GenreImage, y => y.MapFrom(z => Mapper.Map<CreateGenreViewModel, GenreImage>(z)));

            //--------------------------------- Singer ---------------------------------------

            cfg.CreateMap<CreateSingerViewModel, SingerImage>()
                .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.SingerImage.ContentLength]))
                .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.SingerImage.ContentType));

            cfg.CreateMap<CreateSingerViewModel, Singer>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.SingerName))
                .ForMember(x => x.SingerImage, y => y.MapFrom(z => Mapper.Map<CreateSingerViewModel, SingerImage>(z)));

            cfg.CreateMap<EditSingerViewModel, Singer>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.SingerName))
                .ForMember(x => x.SingerImage, y => y.Ignore());

            //----------------------------------- Album ---------------------------------------

            cfg.CreateMap<CreateAlbumViewModel, AlbumImage>()
               .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.AlbumImage.ContentLength]))
               .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.AlbumImage.ContentType));

            cfg.CreateMap<CreateAlbumViewModel, Album>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.AlbumName))
                .ForMember(x => x.AlbumImage, y => y.MapFrom(z => Mapper.Map<CreateAlbumViewModel, AlbumImage>(z)));

            cfg.CreateMap<EditAlbumViewModel, Album>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.AlbumName))
                .ForMember(x => x.AlbumImage, y => y.Ignore());

            //--------------------------------- Playlist ---------------------------------------

            cfg.CreateMap<CreatePlaylistViewModel, PlaylistImage>()
               .ForMember(x => x.ImageData, y => y.MapFrom(z => new byte[z.PlaylistImage.ContentLength]))
               .ForMember(x => x.ImageMimeType, y => y.MapFrom(z => z.PlaylistImage.ContentType));

            cfg.CreateMap<CreatePlaylistViewModel, Playlist>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.PlaylistName))
                .ForMember(x => x.PlaylistImage, y => y.MapFrom(z => Mapper.Map<CreatePlaylistViewModel, PlaylistImage>(z)));

            //-------------------------------- AdminPresentationPage -----------------------------

            cfg.CreateMap<Track, AdminTrackViewModel>()
                .ForMember(x => x.FileLocation, y => y.MapFrom(z => z.TrackFile.FileLocation));

            //-------------------------------- EditAlbumViewModel --------------------------------

            cfg.CreateMap<Album, EditAlbumViewModel>()
                .ForMember(x => x.AlbumName, y => y.MapFrom(z => z.Name));

            //-------------------------------- EditSingerViewModel -------------------------------

            cfg.CreateMap<Singer, EditSingerViewModel>()
                .ForMember(x => x.SingerName, y => y.MapFrom(z => z.Name));

            //-------------------------------- EditTrackViewModel --------------------------------

            cfg.CreateMap<Track, EditTrackViewModel>()
                .ForMember(x => x.TrackName, y => y.MapFrom(z => z.Name));

            //------------------------------- AlbumDetalViewModel --------------------------------

            cfg.CreateMap<Album, AlbumDetailViewModel>()
                .ForMember(x => x.AlbumName, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.AlbumId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LikedTrack, y => y.Ignore())
                .ForMember(x => x.AmountTracks, y => y.Ignore())
                .AfterMap((album, albumView) =>
                {
                    albumView.SingerName = album.Singer.Name;
                });
        }
    }
}