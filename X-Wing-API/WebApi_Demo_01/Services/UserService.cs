using DAL.Entities;
using DAL.Repository;


//permet de s'identifier dans le fichier BaseAuthentificator dans le dossier helper
namespace WebApi_Demo_01.Services
{
    public class UserService : IUserRepository
    {
        private IUserRepository _repo = new UserRepository();

        public bool Check(string username, string password)
        {
            return _repo.Check(username, password);
        }
    }
}
