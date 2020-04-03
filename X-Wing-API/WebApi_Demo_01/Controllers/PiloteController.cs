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
    public class PiloteController : ApiController
    {
        PiloteRepo pilote = new PiloteRepo();
        // GET: api/pilote
        public IEnumerable<ViewModelPilote> Get()
        {
            List<ViewModelPilote> l = new List<ViewModelPilote>();

            foreach (var item in pilote.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntityToViewModel(item));
            }

            return l;
        }

        // GET: api/pilote/5
        [HttpGet]
        public pilotes Get(int id)
        {
            return Mapper.Mapper.MapToEntity(pilote.GetOne(id));
        }
        //get api/pilotes/name
        [Route("api/Pilote/GetByName{name}")]
        [HttpGet]
        public pilotes GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(pilote.GetByName(name));
        }

        // POST: api/Action
        [HttpPost]
        public void Post(pilotes emp)
        {
            Pilote em = new Pilote();
            em = Mapper.Mapper.MapToEntity(emp);
            pilote.Create(em);
        }

        // PUT: api/pilote/5
        [HttpPut]
        public void Put(int id, pilotes emp)
        {
            Pilote em = new Pilote();
            em = Mapper.Mapper.MapToEntity(emp);
            pilote.Update(id, em);
        }

        // DELETE: api/pilote/5
        [HttpDelete]
        public void Delete(int id)
        {
            pilote.Delete(id);
        }
    }
}
