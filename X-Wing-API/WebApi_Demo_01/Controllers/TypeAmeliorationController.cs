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
    public class TypeAmeliorationController : ApiController
    {
        TypeAmeliorationRepo typeAmelioration = new TypeAmeliorationRepo();
        // GET: api/typeAmeliorations
        public IEnumerable<ViewModelType> Get()
        {
            List<ViewModelType> l = new List<ViewModelType>();

            foreach (var item in typeAmelioration.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntityToView(Mapper.Mapper.MapToEntity(item)));
            }

            return l;
        }

        // GET: api/typeAmelioration/5
        [HttpGet]
        public typeAmeliorations Get(int id)
        {
            return Mapper.Mapper.MapToEntity(typeAmelioration.GetOne(id));
        }
        //get api/typeAmelioration/name
        [Route("api/TypeAmelioration/GetByName{name}")]
        [HttpGet]
        public typeAmeliorations GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(typeAmelioration.GetByName(name));
        }

        // POST: api/typeAmelioration
        [HttpPost]
        public void Post(typeAmeliorations emp)
        {
            TypeAmelioration em = new TypeAmelioration();
            em = Mapper.Mapper.MapToEntity(emp);
            typeAmelioration.Create(em);
        }

        // PUT: api/typeAmelioration/5
        [HttpPut]
        public void Put(int id, typeAmeliorations emp)
        {
            TypeAmelioration em = new TypeAmelioration();
            em = Mapper.Mapper.MapToEntity(emp);
            typeAmelioration.Update(id, em);
        }

        // DELETE: api/typeAmelioration/5
        [HttpDelete]
        public void Delete(int id)
        {
            typeAmelioration.Delete(id);
        }
    }
}
