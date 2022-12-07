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

        public class RoomController : ControllerBase
        {
            private readonly IPotionQueries _queries;

            public RoomController(IPotionQueries queries)
            {
                _queries = queries;
            }

            [HttpGet]
            public Task<List<Potion>> GetAllPotions()
            {
                return _queries.GetAllPotions();
            }
        }
    }
}
