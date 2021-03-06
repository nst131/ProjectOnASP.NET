﻿using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface IPlaylistRepository : IBaseRepository<Playlist>
    {
        List<Playlist> GetListPlaylist();
        Playlist GetPlaylistById(int id);
        Playlist GetPlaylistWithImage(int id);
        bool IsExistPlaylist(int id);
        bool IsUniquePlaylist(string playlistName);
    }
}
