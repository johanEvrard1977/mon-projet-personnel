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
    public class CollectionRepo : ICollectionRepo<int, Collection>
    {

        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";
        public void Create(Collection T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_Collection";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@userId", T.XIDUser);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM collection WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<ViewCollection> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM collection";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewCollection
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["id"]
                    };
                }
            }

        }

        public Collection GetByName(string name)
        {
            Collection u = new Collection();
            PiloteRepo PR = new PiloteRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            EscadronRepo ER = new EscadronRepo();
            VaisseauRepo VR = new VaisseauRepo();
            UserRepository UR = new UserRepository();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT collection.ID, collection.Nom"
                    + " FROM collection"
                    + " WHERE collection.Nom = @p1";
                cmd.Parameters.AddWithValue("p1", name);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Pilote = PR.GetLinkCollection((int)r["ID"]);
                    u.Vaisseau = VR.GetLinkCollection((int)r["ID"]);
                    u.Amelioration = AR.GetLinkCollection((int)r["ID"]);
                    u.Escadron = ER.GetLinkCollection((int)r["ID"]);
                }
            }
            return u;
        }

        public IEnumerable<ViewCollection> GetByLinkUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM collection join Users"
                    + " on collection.XIDUsers = collection.ID"
                    + " where Users.UserId = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewCollection
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewCollection> GetLinkEscadron(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM collection join escadron"
                    + " on collection.ID = escdaron.XIDCollection"
                    + " where escadron.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewCollection
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public Collection GetOne(int id)
        {
            Collection u = new Collection();
            PiloteRepo PR = new PiloteRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            EscadronRepo ER = new EscadronRepo();
            VaisseauRepo VR = new VaisseauRepo();
            UserRepository UR = new UserRepository();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *"
                    + " FROM collection"
                    + " WHERE collection.id = @p1";
                cmd.Parameters.AddWithValue("p1", id);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Pilote = PR.GetLinkCollection((int)r["ID"]);
                    u.Vaisseau = VR.GetLinkCollection((int)r["ID"]);
                    u.Amelioration = AR.GetLinkCollection((int)r["ID"]);
                    u.Escadron = ER.GetLinkCollection((int)r["ID"]);
                }
            }
            return u;
        }

        public void Update(int id, Collection T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_Collection";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@user", T.XIDUser);
                cmd.ExecuteNonQuery();
            }
        }

        IEnumerable<Collection> IRepository<int, Collection>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
