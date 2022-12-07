using System.Collections.Generic;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Models.DTOs
{
    public class PotionDTO
    {
        public int StudentId { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
