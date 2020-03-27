using DAL.Repository;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi_Demo_01.Helper;
using WebApiXwing.Models;

namespace WebApi_Demo_01.Controllers
{
    //[BasicAuthenticator(realm: "MIKE8")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ActionController : ApiController
    {
        ActionRepo action = new ActionRepo();
        // GET: api/Action
        [HttpGet]
        public IEnumerable<actions> Get()
        {
            List<actions> l = new List<actions>();

            foreach (var item in action.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntity(item));
            }

            return l;
        }

        // GET: api/Action/5
        [HttpGet]
        public actions Get(int id)
        {
            return Mapper.Mapper.MapToEntity(action.GetOne(id));
        }
        //get api/Action/name
        [Route("api/Action/GetByName/{name}")]
        [HttpGet]
        public actions GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(action.GetByName(name));
        }

        // POST: api/Action
        [HttpPost]
        public void Post(actions emp)
        {
            Actions em = new Actions();
            em = Mapper.Mapper.MapToEntity(emp);
            action.Create(em);
        }

        // PUT: api/Action/5
        [HttpPut]
        public void Put(int id, actions emp)
        {
            Actions em = new Actions();
            em = Mapper.Mapper.MapToEntity(emp);
            action.Update(id, em);
        }

        // DELETE: api/Action/5
        [HttpDelete]
        public void Delete(int id)
        {
            action.Delete(id);
        }
    }
}
