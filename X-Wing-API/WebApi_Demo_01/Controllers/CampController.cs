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
    public class CampController : ApiController
    {
        CampRepo camp = new CampRepo();
        // GET: api/Camp
        public IEnumerable<ViewModelCamp> Get()
        {
            List<ViewModelCamp> l = new List<ViewModelCamp>();

            foreach (var item in camp.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntityToViewModel(item));
            }

            return l;
        }

        // GET: api/Camp/5
        [HttpGet]
        public camps Get(int id)
        {
            return Mapper.Mapper.MapToEntity(camp.GetOne(id));
        }
        //get api/Camp/GetByName/name
        [Route("api/Camp/GetByName/{name}")]
        [HttpGet]
        public camps GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(camp.GetByName(name));
        }

        // POST: api/Camp
        [HttpPost]
        public void Post(camps emp)
        {
            Camp em = new Camp();
            em = Mapper.Mapper.MapToEntity(emp);
            camp.Create(em);
        }

        // PUT: api/Camp/5
        [HttpPut]
        public void Put(int id, camps emp)
        {
            Camp em = new Camp();
            em = Mapper.Mapper.MapToEntity(emp);
            camp.Update(id, em);
        }

        // DELETE: api/Camp/5
        [HttpDelete]
        public void Delete(int id)
        {
            camp.Delete(id);
        }
    }
}
