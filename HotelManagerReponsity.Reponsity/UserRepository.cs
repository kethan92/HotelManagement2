using HotelManagerReponsity.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerReponsity.Reponsity
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private RoomManagerEntities roomManagerEntities;
        //private UserRepository _userRepository;
        private DbSet<User> dbSet;

        public UserRepository()
        {
            roomManagerEntities = new RoomManagerEntities();
            //_userRepository = new UserRepository();
            dbSet = roomManagerEntities.Set<User>();
        }
        public IEnumerable<User> checkLogin(object username, object password)
        {
            yield return dbSet.FirstOrDefault(x => x.username==username && x.password==password);
        }

        
    }
}
