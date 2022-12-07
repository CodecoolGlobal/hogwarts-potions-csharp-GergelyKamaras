using HogwartsPotions.Models.DTOs;
using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsPotions.Services.Interfaces
{
    public interface IPotionQueries
    {
        public Task<List<Potion>> GetAllPotions();
        public Task<List<Potion>> GetPotionsByStudentId(int studentId);
        public Potion AddPotion(PotionDTO potionDTO);
    }
}
