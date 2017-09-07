using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HotelManagerReponsity.Models;
using Repository;
using HotelManagerReponsity.Reponsity;

namespace HotelManagerReponsity.Controllers
{
    public class UsersController : ApiController
    {
        // private IRepository<User> _userRepository;
        private IUserRepository _userRepository;
        // private IRepository<>

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        // GET: api/Users
        [HttpGet]
        public HttpResponseMessage GetUsers()
        {
            var query = _userRepository.GetAll();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, query);
            return response;
        }

        // GET: api/Users?username=?password=?
        [HttpGet]       
        public IHttpActionResult GetUsers(string username,string password)
        {
            var result = _userRepository.checkLogin(username, password);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        


    }
}