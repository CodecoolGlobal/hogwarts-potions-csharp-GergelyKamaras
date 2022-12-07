﻿using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsPotions.Services.Interfaces
{
    public interface IPotionQueries
    {
        public Task<List<Potion>> GetAllPotions();
    }
}
