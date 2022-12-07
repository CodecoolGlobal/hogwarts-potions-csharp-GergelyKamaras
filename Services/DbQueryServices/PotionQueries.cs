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
            return _db.Potions.Include(p => p.Student)
                .Include(p => p.Ingredients)
                .Include(p => p.Recipe)
                .ToListAsync();
        }

        public Task<List<Potion>> GetPotionsByStudentId(int studentId)
        {
            return _db.Potions.Include(p => p.Student)
                .Include(p => p.Ingredients)
                .Include(p => p.Recipe)
                .Where(p => p.Student.ID == studentId)
                .ToListAsync();
        }

        public Potion AddPotion(PotionDTO potionDTO)
        {
            Potion potion = new Potion();
            potion.Student = _db.Students.First(s => s.ID == potionDTO.StudentId);
            potion.Ingredients = potionDTO.Ingredients;

            // If the ingredient already exists in db replace the potions ingredient with it to avoid duplication
            potion.Ingredients.ForEach(i =>
            {
                if (IsIngredientInDb(i))
                {
                    i.ID = _db.Ingredients.First(ingredient => ingredient.Name == i.Name).ID;
                }
            });
            
            potion.BrewingStatus = CalculateBrewingStatus(potion.Ingredients);

            if (potion.BrewingStatus == BrewingStatus.Discovery)
            {
                SaveRecipe(potion);
            }
            
            _db.Potions.Add(potion);
            _db.SaveChanges();
            return potion;
        }

        public Task<List<Recipe>> GetAllRecipes()
        {
            return _db.Recipes.Include(r => r.Ingredients)
                .Include(r => r.Student)
                .ToListAsync();
        }

        public Task<List<Ingredient>> GetAllIngredients()
        {
            return _db.Ingredients.ToListAsync();
        }

        private BrewingStatus CalculateBrewingStatus(List<Ingredient> ingredients)
        {
            if (ingredients.Count < 5)
            {
                return BrewingStatus.Brew;
            }
            else if (DoesRecipeExist(ingredients))
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

        private bool DoesRecipeExist(List<Ingredient> ingredients)
        {
            return (_db.Recipes.Any() && _db.Recipes.Any(r => r.Ingredients.All(i => ingredients.Contains(i))));
        }

        private bool IsIngredientInDb(Ingredient ingredient)
        {
            return _db.Ingredients.Any(ing => ing.Name == ingredient.Name);
        }
    }
}
