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
    public class CampRepo : ICampRepo<int, Camp>
    {

        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";
        public void Create(Camp T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_camp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM camp WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<Camp> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM camp";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Camp
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["id"]
                    };
                }
            }

        }

        public Camp GetOne(int id)
        {
            Camp u = new Camp();
            VaisseauRepo VR = new VaisseauRepo();
            PiloteRepo PR = new PiloteRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT camp.ID, camp.Nom"
                    + " FROM camp"
                    + " WHERE camp.id = @p1";
                cmd.Parameters.AddWithValue("p1", id);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Vaisseau = VR.GetLinkCamp((int)r["ID"]);
                    u.Pilote = PR.GetLinkCamp((int)r["ID"]);
                }
            }
            return u;
        }

        public IEnumerable<Camp> GetLinkVaisseau(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM camp join pilote on pilote.XIDCamp = pilote.ID"
                    + " join vaisseau on vaisseau.ID = pilote.XIDVaisseau where vaisseau.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Camp
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<Camp> GetLinkEscadron(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM camp join escadron on escadron.XIDCamp = camp.ID"
                    + " where escadron.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Camp
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<Camp> GetLinkPilote(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM camp join pilote on pilote.XIDCamp = pilote.ID"
                    + " join vaisseau on vaisseau.ID = pilote.XIDVaisseau where pilote.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Camp
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }


        public Camp GetByName(string name)
        {
            Camp u = new Camp();
            VaisseauRepo VR = new VaisseauRepo();
            PiloteRepo PR = new PiloteRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT camp.ID, camp.Nom"
                    + " FROM camp"
                    + " WHERE camp.id = @p1";
                cmd.Parameters.AddWithValue("p1", name);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Vaisseau = VR.GetLinkCamp((int)r["ID"]);
                    u.Pilote = PR.GetLinkCamp((int)r["ID"]);
                }
            }
            return u;
        }

        

        public void Update(int id, Camp T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_Camp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", T.Id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
