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
    [RoutePrefix("api/Escadron")]
    public class EscadronController : ApiController
    {
        EscadronRepo escadron = new EscadronRepo();
        // GET: api/escadron
        public IEnumerable<escadrons> Get()
        {
            List<escadrons> l = new List<escadrons>();

            foreach (var item in escadron.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntity(item));
            }

            return l;
        }

        // GET: api/escadrons/5
        [HttpGet]
        public escadrons Get(int id)
        {
            return Mapper.Mapper.MapToEntity(escadron.GetOne(id));
        }
        //get api/escadron/name
        [Route("api/Escadron/GetByName/{name}")]
        [HttpGet]
        public escadrons GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(escadron.GetByName(name));
        }

        // POST: api/escadron
        [HttpPost]
        public void Post(escadrons emp)
        {
            Escadron em = new Escadron();
            em = Mapper.Mapper.MapToEntity(emp);
            escadron.Create(em);
        }

        // PUT: api/escadron/5
        [HttpPut]
        public void Put(int id, escadrons emp)
        {
            Escadron em = new Escadron();
            em = Mapper.Mapper.MapToEntity(emp);
            escadron.Update(id, em);
        }

        // DELETE: api/escadron/5
        [HttpDelete]
        public void Delete(int id)
        {
            escadron.Delete(id);
        }
    }
}
