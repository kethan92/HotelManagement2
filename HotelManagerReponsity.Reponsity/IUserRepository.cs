using HotelManagerReponsity.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerReponsity.Reponsity
{
    public interface IUserRepository:IRepository<User>
    {
        IEnumerable<User> checkLogin(object username, object password);
    }
}
