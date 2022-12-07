using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Data;
using HogwartsPotions.Models.DTOs;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;
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

        public Potion AddPotion(PotionDTO potionDTO)
        {
            Potion potion = new Potion();
            potion.Student = _db.Students.First(s => s.ID == potionDTO.StudentId);
            potion.Ingredients = potionDTO.Ingredients;
            potion.BrewingStatus = CalculateBrewingStatus(potion.Ingredients);

            if (potion.BrewingStatus == BrewingStatus.Discovery)
            {
                SaveRecipe(potion);
            }
            
            _db.Potions.Add(potion);
            _db.SaveChanges();
            return _db.Potions.First(p => Equals(potion));
        }

        private BrewingStatus CalculateBrewingStatus(List<Ingredient> ingredients)
        {
            if (ingredients.Count < 5)
            {
                return BrewingStatus.Brew;
            }
            else if (_db.Potions.Any(p => p.Ingredients.SequenceEqual(ingredients)))
            {
                return BrewingStatus.Replica;
            }
            else
            {
                return BrewingStatus.Discovery;
            }
        }

        private void SaveRecipe(Potion potion)
        {
            _db.Recipes.Add(new Recipe(potion.Student, potion.Ingredients));
            _db.SaveChanges();
        }
    }
}
