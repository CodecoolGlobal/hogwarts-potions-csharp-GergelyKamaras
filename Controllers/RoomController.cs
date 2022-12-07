using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Data;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("/room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomQueries _queries;

        public RoomController(IRoomQueries queries)
        {
            _queries = queries;
        }

        [HttpGet]
        public async Task<List<Room>> GetAllRooms()
        {
            return await _queries.GetAllRooms();
        }

        [HttpPost]
        public async  Task AddRoom([FromBody] Room room)
        {
            await _queries.AddRoom(room);
        }

        [HttpGet("/{id}")]
        public async Task<Room> GetRoomById(long id)
        {
            return await _queries.GetRoom(id);
        }

        [HttpPut("/{id}")]
        public void UpdateRoomById(long id, [FromBody] Room updatedRoom)
        {
            _queries.UpdateRoom(updatedRoom);
        }

        [HttpDelete("/{id}")]
        public async Task DeleteRoomById(long id)
        {
            await _queries.DeleteRoom(id);
        }

        [HttpGet("/rat-owners")]
        public async Task<List<Room>> GetRoomsForRatOwners()
        {
            return await _queries.GetRoomsForRatOwners();
        }
    }
}
