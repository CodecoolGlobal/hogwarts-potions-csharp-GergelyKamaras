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
        public Potion AddCompletePotion(PotionDTO potionDTO);
        public Potion StartBrewing(long studentId);
        public Task<List<Recipe>> GetAllRecipes();
        public Task<List<Ingredient>> GetAllIngredients();
    }
}
