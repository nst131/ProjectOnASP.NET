﻿using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        List<Genre> GetListGenre();
        bool IsUniqueGenre(string genreName);
    }
}
