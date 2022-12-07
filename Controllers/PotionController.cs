using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.DTOs;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("/potions")]
    public class PotionController : ControllerBase
    {
        private readonly IPotionQueries _queries;
        public PotionController(IPotionQueries queries)
        {
            _queries = queries;
        }

        [HttpGet]
        public Task<List<Potion>> GetAllPotions()
        {
            return _queries.GetAllPotions();
        }

        [HttpGet]
        [Route("recipes")]
        public Task<List<Recipe>> GetAllRecipes()
        {
            return _queries.GetAllRecipes();
        }

        [HttpGet]
        [Route("ingredients")]
        public Task<List<Ingredient>> GetAllIngredients()
        {
            return _queries.GetAllIngredients();
        }

        [HttpGet]
        [Route("{studentId}")]
        public Task<List<Potion>> GetPotionsByStudentId(int studentId)
        {
            return _queries.GetPotionsByStudentId(studentId);
        }

        [HttpPost]
        public Potion AddPotion(PotionDTO potionDto)
        {
            return _queries.AddPotion(potionDto);
        }
    }
}
