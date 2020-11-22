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
    public class NoveltyRepository : BaseRepository<Novelty>, INoveltyRepository
    {
        public NoveltyRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<Novelty> GetListNovelty()
        {
            return GetQueryable().ToList();
        }

        public Novelty GetNoveltyById(int id)
        {
            return GetQueryable()
                .FirstOrDefault(x => x.Id == id);
        }

        private List<Track> GetNoveltyTracksByKindOfTrack(string name)
        {
            return GetQueryable()
                .Where(x => x.Name == name)
                .Include(x => x.Tracks)
                .Include(x => x.Tracks.Select(y => y.Singer))
                .Include(x => x.Tracks.Select(y => y.TrackFile))
                .FirstOrDefault()
                .Tracks.ToList();
        }

        public List<Track> GetRandomNoveltysTracksIdByQuantityTracks(int numberTracks)
        {
            List<Track> tracks = GetNoveltyTracksByKindOfTrack(KindOfTrack.Novelty);
            List<Track> noveltyTracks = new List<Track>();
            Random random = new Random();

            if (tracks.Count >= numberTracks)
            {
                for (int i = 0; i < numberTracks; i++)
                {
                    var elem = tracks[random.Next(tracks.Count)];
                    noveltyTracks.Add(elem);
                    tracks.Remove(elem);
                }

                return noveltyTracks;
            }

            for (int i = 0; i < numberTracks; i++)
            {
                noveltyTracks.Add(tracks[random.Next(tracks.Count)]);
            }

            return noveltyTracks;
        }
    }
}
