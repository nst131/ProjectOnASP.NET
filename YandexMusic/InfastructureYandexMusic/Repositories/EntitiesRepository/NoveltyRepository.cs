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

        private List<int> GetNoveltyTracksIdByName(string name)
        {
            return GetQueryable()
                .Where(x => x.Name == name)
                .Include(x => x.Tracks)
                .SingleOrDefault()
                .Tracks.Select(x => x.Id).ToList();
        }

        public List<int> GetRandomNoveltyTracksIdByQuantityTracks(int numberTracks)
        {
            List<int> tracksId = GetNoveltyTracksIdByName(KindOfTrack.Novelty);
            List<int> vs = new List<int>();
            Random random = new Random();

            if (tracksId.Count >= numberTracks)
            {
                for (int i = 0; i < numberTracks; i++)
                {
                    var elem = tracksId[random.Next(tracksId.Count)];
                    vs.Add(elem);
                    tracksId.Remove(elem);
                }

                return vs;
            }

            for (int i = 0; i < numberTracks; i++)
            {
                vs.Add(tracksId[random.Next(tracksId.Count)]);
            }

            return vs;
        }
    }
}
