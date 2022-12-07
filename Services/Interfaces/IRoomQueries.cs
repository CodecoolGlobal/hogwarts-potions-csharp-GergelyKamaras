using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HogwartsPotions.Services.Interfaces
{
    public interface IRoomQueries
    {
        public Task AddRoom(Room room);
        public Task<Room> GetRoom(long roomId);
        public Task<List<Room>> GetAllRooms();
        public Task UpdateRoom(Room room);
        public Task DeleteRoom(long id);
        public Task<List<Room>> GetRoomsForRatOwners();
    }
}