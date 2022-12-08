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

        // Potions

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

        public Potion AddCompletePotion(PotionDTO potionDTO)
        {
            Potion potion = new Potion();
            potion.Student = _db.Students.First(s => s.ID == potionDTO.StudentId);
            potion.Ingredients = potionDTO.Ingredients;

            // If the ingredient already exists in db replace the potions ingredient  object reference with it to avoid db duplication
            for (int i = 0; i < potion.Ingredients.Count; i++)
            {
                if (IsIngredientInDb(potion.Ingredients[i]))
                {
                    potion.Ingredients[i] = _db.Ingredients.First(ingredient => ingredient.Name == potion.Ingredients[i].Name);
                }
            }
            
            potion.BrewingStatus = CalculateBrewingStatus(potion.Ingredients);
            potion.Recipe = AssignRecipeToPotion(potion);

            _db.Potions.Add(potion);
            _db.SaveChanges();
            return potion;
        }

        // Brewing
        public Potion StartBrewing(long studentId)
        {
            Potion potion = new Potion();
            potion.Student = _db.Students.First(s => s.ID == studentId);
            potion.BrewingStatus = BrewingStatus.Brew;

            _db.Potions.Add(potion);
            _db.SaveChanges();

            return potion;
        }

        public Potion AddIngredient(int potionId, Ingredient ingredient)
        {
            Potion potion = _db.Potions.Include(p => p.Student)
                .Include(p => p.Ingredients)
                .First(s => s.ID == potionId);
            if (_db.Ingredients.Any(i => i.Name == ingredient.Name))
            {
                ingredient = _db.Ingredients.First(i => i.Name == ingredient.Name);
            }
            potion.Ingredients.Add(ingredient);

            potion.BrewingStatus = CalculateBrewingStatus(potion.Ingredients);

            if (potion.Ingredients.Count > 4)
            {
                potion.Recipe = AssignRecipeToPotion(potion);
            }
            
            _db.SaveChanges();

            return potion;
        }

        // Misc.

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

        // Util

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

        private Recipe SaveAndReturnRecipe(Potion potion)
        {
            Recipe recipe = new Recipe(potion.Student, potion.Ingredients);
            _db.Recipes.Add(recipe);
            _db.SaveChanges();
            return recipe;
        }

        private Recipe AssignRecipeToPotion(Potion potion)
        {
            if (potion.BrewingStatus == BrewingStatus.Discovery)
            {
                return SaveAndReturnRecipe(potion);
            }
            else
            {
                return _db.Recipes.First(r => r.Ingredients.All(i => potion.Ingredients.Contains(i)));
            }
        }

        private bool DoesRecipeExist(List<Ingredient> ingredients)
        {
            return (_db.Recipes.Any(r => r.Ingredients.All(i => ingredients.Contains(i))));
        }

        private bool IsIngredientInDb(Ingredient ingredient)
        {
            return _db.Ingredients.Any(ing => ing.Name == ingredient.Name);
        }
    }
}
