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
using WebApi_Demo_01.ViewModels;

namespace WebApi_Demo_01.Controllers
{
    [BasicAuthenticator(realm: "MIKE8")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CollectionController : ApiController
    {
        CollectionRepo collection = new CollectionRepo();
        // GET: api/Collection
        public IEnumerable<ViewModelCollection> Get()
        {
            List<ViewModelCollection> l = new List<ViewModelCollection>();

            foreach (var item in collection.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntityToViewModel(item));
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

        // POST: api/Collection
        [Route("api/Collection/PostElements/{collection}")]
        [HttpPost]
        public void PostElements(collections emp)
        {
            Collection em = new Collection();
            em = Mapper.Mapper.MapToEntity(emp);
            collection.InsertIntoCollection(em);
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

        // DELETE: api/Collection/DeleteVaisseau
        [Route("api/Collection/DeleteVaisseau/{vaisseauId}/{collectionId}")]
        [HttpDelete]
        public void DeleteVaisseau(int idV, int idC)
        {
            collection.DeleteVaisseau(idV, idC);
        }
    }
}
