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
using WebApi_Demo_01.Models;

namespace WebApi_Demo_01.Controllers
{
    [BasicAuthenticator(realm: "MIKE8")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Collection")]
    public class CollectionController : ApiController
    {
        CollectionRepo collection = new CollectionRepo();
        // GET: api/Collection
        public IEnumerable<collections> Get()
        {
            List<collections> l = new List<collections>();

            foreach (var item in collection.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntity(item));
            }

            return l;
        }

        // GET: api/Collection/5
        [HttpGet]
        public collections Get(int id)
        {
            return Mapper.Mapper.MapToEntity(collection.GetOne(id));
        }
        //get api/Collection/name
        [Route("api/Collection/GetByName/{name}")]
        [HttpGet]
        public collections GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(collection.GetByName(name));
        }

        // POST: api/Collection
        [HttpPost]
        public void Post(collections emp)
        {
            Collection em = new Collection();
            em = Mapper.Mapper.MapToEntity(emp);
            collection.Create(em);
        }

        // PUT: api/Collection/5
        [HttpPut]
        public void Put(int id, collections emp)
        {
            Collection em = new Collection();
            em = Mapper.Mapper.MapToEntity(emp);
            collection.Update(id, em);
        }

        // DELETE: api/Collection/5
        [HttpDelete]
        public void Delete(int id)
        {
            collection.Delete(id);
        }
    }
}
