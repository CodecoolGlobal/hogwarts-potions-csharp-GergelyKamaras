using HogwartsPotions.Models.DTOs;
using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsPotions.Services.Interfaces
{
    public interface IPotionQueries
    {
        public Task<List<Potion>> GetAllPotions();
        public Potion GetPotionById(int id);
        public Task<List<Potion>> GetPotionsByStudentId(int studentId);
        public Potion AddCompletePotion(PotionDTO potionDTO);
        public Potion StartBrewing(long studentId);
        public Potion AddIngredient(int potionId, Ingredient ingredient);
        public List<Recipe> GetHelp(List<Ingredient> ingredients);
        public Task<List<Recipe>> GetAllRecipes();
        public Task<List<Ingredient>> GetAllIngredients();
    }
}
