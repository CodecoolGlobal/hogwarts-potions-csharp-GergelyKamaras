using System.ComponentModel.DataAnnotations.Schema;
using HogwartsPotions.Models.Enums;

namespace HogwartsPotions.Models.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Name { get; set; }
        public HouseType HouseType { get; set; }
        public PetType PetType { get; set; }
        public int NumberOfPotions { get; set; } = 0;
        public int NumberOfDiscoveries { get; set; } = 0;
        
        public Room Room { get; set; }

        public Student()
        {
            
        }

        public Student(string name, HouseType house, PetType pet, Room room)
        {
            Name = name;
            HouseType = house;
            PetType = pet;
            Room = room;
        }
        public Student(string name, HouseType house, PetType pet)
        {
            Name = name;
            HouseType = house;
            PetType = pet;
        }
    }
}
