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
    public class AmeliorationController : ApiController
    {
        AmeliorationRepo amelioration = new AmeliorationRepo();
        // GET: api/Action
        public IEnumerable<ameliorations> Get()
        {
            List<ameliorations> l = new List<ameliorations>();

            foreach (var item in amelioration.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntity(item));
            }

            return l;
        }

        // GET: api/Action/5
        [HttpGet]
        public ameliorations Get(int id)
        {
            return Mapper.Mapper.MapToEntity(amelioration.GetOne(id));
        }
        //get api/Action/name
        [Route("api/Amelioration/GetByName/{name}")]
        [HttpGet]
        public ameliorations GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(amelioration.GetByName(name));
        }

        // POST: api/Action
        
        [HttpPost]
        public void Post(ameliorations emp)
        {
            Amelioration em = new Amelioration();
            em = Mapper.Mapper.MapToEntity(emp);
            amelioration.Create(em);
        }

        // PUT: api/Amelioration/5
        [HttpPut]
        public void Put(int id, ameliorations emp)
        {
            Amelioration em = new Amelioration();
            em = Mapper.Mapper.MapToEntity(emp);
            amelioration.Update(id, em);
        }

        // DELETE: api/Amelioration/5
        [HttpDelete]
        public void Delete(int id)
        {
            amelioration.Delete(id);
        }
    }
}
