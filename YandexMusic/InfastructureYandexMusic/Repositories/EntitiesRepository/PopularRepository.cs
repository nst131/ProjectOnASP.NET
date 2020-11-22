using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using InfastructureYandexMusic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class PopularRepository : BaseRepository<Popular>, IPopularRepository
    {
        public PopularRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<Popular> GetListPopular()
        {
            return GetQueryable().ToList();
        }

        public Popular GetPopularById(int id)
        {
            return GetQueryable()
                .FirstOrDefault(x => x.Id == id);
        }

        private List<Track> GetPopularTracksByKindOfTrack(string name)
        {
            return GetQueryable()
                .Where(x => x.Name == name)
                .Include(x => x.Tracks)
                .Include(x => x.Tracks.Select(y => y.Singer))
                .Include(x => x.Tracks.Select(y => y.TrackFile))
                .FirstOrDefault()
                .Tracks.ToList();
        }

        public List<Track> GetRandomPopularsTracksIdByQuantityTracks(int numberTracks)
        {
            List<Track> tracks = GetPopularTracksByKindOfTrack(KindOfTrack.Popular);
            List<Track> popularTracks = new List<Track>();
            Random random = new Random();

            if (tracks.Count >= numberTracks)
            {
                for (int i = 0; i < numberTracks; i++)
                {
                    var elem = tracks[random.Next(tracks.Count)];
                    popularTracks.Add(elem);
                    tracks.Remove(elem);
                }

                return popularTracks;
            }

            for (int i = 0; i < numberTracks; i++)
            {
                popularTracks.Add(tracks[random.Next(tracks.Count)]);
            }

            return popularTracks;
        }
    }
}