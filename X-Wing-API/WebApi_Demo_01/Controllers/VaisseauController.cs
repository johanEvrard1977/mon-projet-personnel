﻿using DAL.Repository;
using DalXwing.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi_Demo_01.Helper;
using WebApi_Demo_01.Models;
using WebApi_Demo_01.ViewModels;

namespace WebApi_Demo_01.Controllers
{
    [BasicAuthenticator(realm: "MIKE8")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VaisseauController : ApiController
    {
        VaisseauRepo vaisseau = new VaisseauRepo();
        // GET: api/vaisseau
        public IEnumerable<ViewModelVaisseau> Get()
        {
            List<ViewModelVaisseau> l = new List<ViewModelVaisseau>();

            foreach (var item in vaisseau.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntityToViewModel(item));
            }

            return l;
        }

        // GET: api/vaisseau/5
        [HttpGet]
        public vaisseaux Get(int id)
        {
            return Mapper.Mapper.MapToEntity(vaisseau.GetOne(id));
        }
        //get api/vaisseaux/name
        [Route("api/Vaisseau/GetByName{name}")]
        [HttpGet]
        public vaisseaux GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(vaisseau.GetByName(name));
        }

        // POST: api/vaisseau
        [HttpPost]
        public void Post(vaisseaux emp)
        {
            Vaisseaux em = new Vaisseaux();
            em = Mapper.Mapper.MapToEntity(emp);
            vaisseau.Create(em);
        }

        // PUT: api/vaisseau/5
        [HttpPut]
        public void Put(int id, vaisseaux emp)
        {
            Vaisseaux em = new Vaisseaux();
            em = Mapper.Mapper.MapToEntity(emp);
            vaisseau.Update(id, em);
        }

        // DELETE: api/vaisseau/5
        [HttpDelete]
        public void Delete(int id)
        {
            vaisseau.Delete(id);
        }
    }
}
