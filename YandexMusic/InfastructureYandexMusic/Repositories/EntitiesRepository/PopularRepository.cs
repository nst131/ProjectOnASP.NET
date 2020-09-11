﻿using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class PopularRepository : BaseRepository<Popular>, IPopularRepository
    {
        public PopularRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
