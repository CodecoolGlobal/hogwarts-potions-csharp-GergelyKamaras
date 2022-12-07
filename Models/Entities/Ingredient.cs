﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HogwartsPotions.Models.Entities
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }

        public Ingredient()
        {
            
        }

        public Ingredient(string name)
        {
            Name = name;
        }
    }
}