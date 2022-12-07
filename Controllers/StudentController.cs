using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentQueries _queries;
        public StudentController(IStudentQueries queries)
        {
            _queries = queries;
        }

        [HttpGet]
        public Task<List<Student>> GetAllStudents()
        {
            return _queries.GetAllStudents();
        }
    }
}
