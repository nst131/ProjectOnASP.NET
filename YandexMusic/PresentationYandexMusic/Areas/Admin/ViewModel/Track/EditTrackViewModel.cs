using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.ViewModel.Track
{
    public class EditTrackViewModel
    {
        public int Id { get; set; }

        public string TrackName { get; set; }

        public DateTime TimeOfCreation { get; set; }

        public int Liked { get; set; }

        public int SingerId { get; set; }
        public SelectList SelectListSingers { get; set; }

        public int[] PlaylistArrayId { get; set; }
        public Dictionary<int, string> PlaylistList { get; set; }

        public int AlbumId { get; set; }
        public SelectList SelectListAlbums { get; set; }

        public int GenreId { get; set; }
        public SelectList SelectListGenre { get; set; }

        public int NoveltyId { get; set; }
        public Dictionary<int, string> NoveltyList { get; set; }

        public int PopularId { get; set; }
        public Dictionary<int, string> PopularList { get; set; }

        public HttpPostedFileBase TrackImage { get; set; }
        public HttpPostedFileBase TrackFile { get; set; }
    }
}