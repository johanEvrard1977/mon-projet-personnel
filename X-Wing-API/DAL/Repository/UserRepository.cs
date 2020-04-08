using DAL.Entities;
using DAL.ViewModels;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";

        public bool Check(string username, string password)
        {
            User u = new User();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Users where UserName = @p1 and Password = @p2";
                cmd.Parameters.AddWithValue("@p1", username);
                cmd.Parameters.AddWithValue("@p2", password);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.UserName = r["UserName"].ToString();
                    u.ID = (int)r["UserId"];
                }
            }
            return u != null;
        }

         public void Create(User T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_User";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", T.Prenom);
                cmd.Parameters.AddWithValue("@LastName", T.Nom);
                cmd.Parameters.AddWithValue("@UserName", T.UserName);
                cmd.Parameters.AddWithValue("@pass", T.Password);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Users WHERE UserId = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Users";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new User
                    {
                        Nom = r["Nom"].ToString(),
                        ID = (int)r["UserId"]
                    };
                }
            }
        }

        public IEnumerable<ViewUser> GetLinkCollection(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Users join collection"
                    + " on collection.XIDUsers = Users.UserId"
                    + "  where collection.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewUser
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["UserId"]
                };
                }
            }
        }

        public User GetByName(string name)
        {
            User u = new User();
            CollectionRepo CR = new CollectionRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * from Users where Users.Nom = @p1";
                cmd.Parameters.AddWithValue("@p1", name);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Nom = r["Nom"].ToString();
                    u.Prenom = r["Prenom"].ToString();
                    u.ID = (int)r["UserId"];
                    u.UserName = r["UserName"].ToString();
                    u.Role = r["Role"].ToString();
                    u.Password = "******";
                    u.Collection = CR.GetByLinkUser((int)r["UserId"]);
                }
            }
            return u;
        }


        public User GetOne(int id)
        {
            User u = new User();
            CollectionRepo CR = new CollectionRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * from Users where Users.UserId = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Nom = r["Nom"].ToString();
                    u.Prenom = r["Prenom"].ToString();
                    u.ID = (int)r["UserId"];
                    u.UserName = r["UserName"].ToString();
                    u.Role = r["Role"].ToString();
                    u.Password = "******";
                    u.Collection = CR.GetByLinkUser((int)r["UserId"]);
                }
            }
            return u;
        }

        public void Update(int id, User T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_Action";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@FirstName", T.Prenom);
                cmd.Parameters.AddWithValue("@LastName", T.Nom);
                cmd.Parameters.AddWithValue("@UserName", T.UserName);
                cmd.Parameters.AddWithValue("@pass", T.Password);
                cmd.Parameters.AddWithValue("@Role", T.Role);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
