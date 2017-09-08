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
using HotelManagerReponsity.Reponsity;
using HotelManagerReponsity.ViewModel;

namespace HotelManagerReponsity.Controllers
{
    public class RoomsController : ApiController
    {
        private RoomManagerEntities db = new RoomManagerEntities();
        private IRoomRepository _roomRepository;
        private IRoom_StatusRepository _roomStatusRepository;
        public RoomsController()
        {
            _roomRepository = new RoomRepository();
            _roomStatusRepository = new Room_StatusRepository();
        }

        // GET: api/Rooms
        [HttpGet]
        public HttpResponseMessage GetRooms()
        {
            var query = from a in _roomRepository.GetAll().Include("_roomStatusRepository.GetAll()")
                        select new RoomStatus
                        {
                            RoomNumber=a.RoomNumber,
                            nameRoom=a.nameRoom,
                            RoomStatus_id=a.RoomStatus_id,
                            RoomType_id=a.RoomType_id,
                            status=a.Room_Status.status
                        };
            
             HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, query);
             return response;
        }

        // GET: api/Rooms/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult GetRoom(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // PUT: api/Rooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoom(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room.RoomNumber)
            {
                return BadRequest();
            }

            db.Entry(room).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rooms
        [ResponseType(typeof(Room))]
        public IHttpActionResult PostRoom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rooms.Add(room);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoomExists(room.RoomNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = room.RoomNumber }, room);
        }

        // DELETE: api/Rooms/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult DeleteRoom(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            db.Rooms.Remove(room);
            db.SaveChanges();

            return Ok(room);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomExists(int id)
        {
            return db.Rooms.Count(e => e.RoomNumber == id) > 0;
        }
    }
}