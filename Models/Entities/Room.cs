using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogwartsPotions.Models.Entities
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity => MaxCapacity - Residents.Count;
        public HashSet<Student> Residents { get; set; } = new HashSet<Student>();

        public Room(int maxCapacity)
        {
            MaxCapacity = maxCapacity;
        }
    }
}
