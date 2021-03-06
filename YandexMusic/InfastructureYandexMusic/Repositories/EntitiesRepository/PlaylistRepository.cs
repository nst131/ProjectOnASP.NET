﻿using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class PlaylistRepository : BaseRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public bool IsUniquePlaylist(string playlistName)
        {
            return !GetQueryable().Any(x => x.Name == playlistName);
        }

        public List<Playlist> GetListPlaylist()
        {
            return GetQueryable().ToList();
        }

        public Playlist GetPlaylistById(int id)
        {
            return GetQueryable()
                .FirstOrDefault(x => x.Id == id);
        }

        public bool IsExistPlaylist(int id)
        {
            return GetQueryable()
                .Any(x => x.Id == id);
        }

        public Playlist GetPlaylistWithImage(int id)
        {
            return GetQueryable()
                .Include(x => x.PlaylistImage)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
