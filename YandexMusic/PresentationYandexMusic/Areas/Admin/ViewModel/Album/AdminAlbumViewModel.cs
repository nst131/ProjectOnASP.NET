using PresentationYandexMusic.Areas.Admin.ViewModel.Track;
using System.Collections.Generic;

namespace PresentationYandexMusic.Areas.Admin.ViewModel.Album
{
    public class AdminAlbumViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AdminTrackViewModel> Tracks { get; set; }
    }
}