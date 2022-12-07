using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Data;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Services.DbQueryServices
{
    public class StudentQueries : IStudentQueries
    {
        private HogwartsContext _db;

        public StudentQueries(HogwartsContext context)
        {
            _db = context;
        }

        public Task<List<Student>> GetAllStudents()
        {
            return _db.Students.ToListAsync();
        }
    }
}
