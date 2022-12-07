using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using HogwartsPotions.Data;
using HogwartsPotions.Models.Enums;
using HogwartsPotions.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Services.DbQueryServices
{
    public class RoomQueries : IRoomQueries
    {
        private HogwartsContext _db;

        public RoomQueries(HogwartsContext context)
        {
            _db = context;
        }
        public async Task AddRoom(Room room)
        {
            _db.Rooms.Add(room);
        }

        public Task<Room> GetRoom(long roomId)
        {
            return _db.Rooms.FirstAsync(r => r.ID == roomId);
        }

        public Task<List<Room>> GetAllRooms()
        {
            return _db.Rooms.ToListAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _db.Rooms.Update(room);
        }

        public async Task DeleteRoom(long id)
        {
            _db.Rooms.Remove(_db.Rooms.First(r => r.ID == id));
        }

        public Task<List<Room>> GetRoomsForRatOwners()
        {
            return _db.Rooms.Where(r => r.Residents.All(s => s.PetType != PetType.Cat && s.PetType != PetType.Owl)).ToListAsync();
        }
    }
}
