using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Data;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Services.DbQueryServices
{
    public class PotionQueries : IPotionQueries
    {
        private HogwartsContext _db;
        public PotionQueries(HogwartsContext context)
        {
            _db = context;
        }

        public Task<List<Potion>> GetAllPotions()
        {
            return _db.Potions.ToListAsync();
        }

        public Task<List<Potion>> GetPotionsByStudentId(int studentId)
        {
            return _db.Potions.Where(p => p.Student.ID == studentId).ToListAsync();
        }


    }
}
