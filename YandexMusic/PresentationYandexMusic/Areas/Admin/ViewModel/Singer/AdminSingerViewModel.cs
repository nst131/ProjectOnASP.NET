using PresentationYandexMusic.Areas.Admin.ViewModel.Album;
using System.Collections.Generic;

namespace PresentationYandexMusic.Areas.Admin.ViewModel.Singer
{
    public class AdminSingerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AdminAlbumViewModel> Albums { get; set; }
    }
}