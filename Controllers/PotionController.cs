using System.Collections.Generic;
using System.Threading.Tasks;
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
        [Route("{studentId}")]
        public Task<List<Potion>> GetPotionsByStudentId(int studentId)
        {
            return _queries.GetPotionsByStudentId(studentId);
        }
    }
}
