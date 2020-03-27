using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi_Demo_01.Helper;
using WebApi_Demo_01.Models;

namespace WebApi_Demo_01.Controllers
{
    [BasicAuthenticator(realm: "MIKE8")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User")]
    public class UsersController : ApiController
    {
        UserRepository user = new UserRepository();
        // GET: api/Users
        public IEnumerable<Users> Get()
        {
            List<Users> l = new List<Users>();

            foreach (var item in user.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntity(item));
            }

            return l;
        }

        // GET: api/User/5
        [HttpGet]
        public Users Get(int id)
        {
            return Mapper.Mapper.MapToEntity(user.GetOne(id));
        }
        //get api/User/name
        [Route("api/User/GetByName/{name}")]
        [HttpGet]
        public Users GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(user.GetByName(name));
        }

        // POST: api/User
        [HttpPost]
        public void Post(Users emp)
        {
            User em = new User();
            em = Mapper.Mapper.MapToEntity(emp);
            user.Create(em);
        }

        // PUT: api/User/5
        [HttpPut]
        public void Put(int id, Users emp)
        {
            User em = new User();
            em = Mapper.Mapper.MapToEntity(emp);
            user.Update(id, em);
        }

        // DELETE: api/User/5
        [HttpDelete]
        public void Delete(int id)
        {
            user.Delete(id);
        }
    }
}
