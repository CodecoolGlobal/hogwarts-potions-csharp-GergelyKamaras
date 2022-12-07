using System.Linq;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;

namespace HogwartsPotions.Models
{
    public static class DbInit
    {
        public static void Init(HogwartsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            context.Students.AddRange(new Student[]
            {
                new Student("Harry", HouseType.Gryffindor, PetType.Owl),
                new Student("Ron", HouseType.Gryffindor, PetType.Rat),
                new Student("Luna", HouseType.Ravenclaw, PetType.None),
                new Student("Draco", HouseType.Slytherin, PetType.None),
                new Student("Hermione", HouseType.Gryffindor, PetType.Cat)
            });
            
            context.SaveChanges();

            context.Rooms.AddRange(new Room[]
            {
                new Room(5),
                new Room(5)
            });

            context.SaveChanges();

            Student Harry = context.Students.First(s => s.Name == "Harry");
            Student Ron= context.Students.First(s => s.Name == "Ron");
            Student Luna= context.Students.First(s => s.Name == "Luna");
            Student Draco= context.Students.First(s => s.Name == "Draco");
            Student Hermione= context.Students.First(s => s.Name == "Hermione");

            Room firstRoom = context.Rooms.First();
            firstRoom.Residents.Add(Harry);
            firstRoom.Residents.Add(Ron);
            firstRoom.Residents.Add(Luna);
            firstRoom.Residents.Add(Draco);
            firstRoom.Residents.Add(Hermione);

            context.SaveChanges();
        }
    }
}
