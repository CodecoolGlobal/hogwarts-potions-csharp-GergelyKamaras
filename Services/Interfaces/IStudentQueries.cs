using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsPotions.Services.Interfaces
{
    public interface IStudentQueries
    {
        public Task<List<Student>> GetAllStudents();
    }
}
