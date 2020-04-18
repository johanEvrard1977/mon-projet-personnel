using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi_Demo_01.Helper;
using WebApi_Demo_01.Models;
using WebApi_Demo_01.ViewModels;

namespace WebApi_Demo_01.Controllers
{
    [BasicAuthenticator(realm: "MIKE8")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        UserRepository user = new UserRepository();
        // GET: api/Users
        public IEnumerable<ViewUserModel> Get()
        {
            List<ViewUserModel> l = new List<ViewUserModel>();

            foreach (var item in user.GetAll())
            {
                l.Add(Mapper.Mapper.MapToEntityToView(Mapper.Mapper.MapToEntity(item)));
            }

            return l;
        }

        // GET: api/Users/5
        [HttpGet]
        public Users Get(int id)
        {
            return Mapper.Mapper.MapToEntity(user.GetOne(id));
        }
        //get api/Users/GetByName/name
        [Route("api/Users/GetByName/{name}")]
        [HttpGet]
        public Users GetByName(string name)
        {
            return Mapper.Mapper.MapToEntity(user.GetByName(name));
        }

        //check api/Users/Check/username/password
        [Route("api/Users/Check/{username}/{password}")]
        [HttpGet]
        public bool Check(string username, string password)
        {
            return user.Check(username, password); 
        }

        [Route("api/Users/CheckUserForPass")]
        [HttpPost]
        public void CheckUserForPass(Users T)
        {
            User u = user.GetByMail(T.Mail);
            if (u != null)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("johan@X-Wing.be");
                mail.To.Add(T.Mail);
                mail.Subject = "Réinitialisation du mot de passe";
                mail.Body = "Bonjour"
                            + "Veuillez cliquer sur le lien afin de réinitialiser votre mot de passe"
                            + " http://localhost:4200/PassInit/" + u.UserName;

                /* Attachment attachment;
                 attachment = new Attachment("c:/textfile.txt");
                 mail.Attachments.Add(attachment);*/
                using (SmtpClient smtp = new SmtpClient("127.0.0.1", 25))
                {
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (SmtpException e)
                    {
                        Console.Write(e.Message);
                    }
                }
            }
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
            user.UpdatePass(id, em);
        }


        [Route("api/Users/PutPass/{id}")]
        [HttpPut]
        public void PutPass(int id, Users emp)
        {
            User em = new User();
            em = Mapper.Mapper.MapToEntity(emp);
            user.UpdatePass(id, em);
        }

        // DELETE: api/User/5
        [HttpDelete]
        public void Delete(int id)
        {
            user.Delete(id);
        }
    }
}
