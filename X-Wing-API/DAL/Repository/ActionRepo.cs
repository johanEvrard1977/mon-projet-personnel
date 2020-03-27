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
    public class ActionRepo: IActionRepo<int, Actions>
    {
        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";

        public void Create(Actions T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_Action";
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
                cmd.CommandText = "DELETE FROM action WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Actions> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM action";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Actions
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["id"]
                    };
                }
            }
        }

        public Actions GetByName(string name)
        {
            Actions u = new Actions();
            VaisseauRepo VR = new VaisseauRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT action.ID, action.Nom"
                    + " FROM action"
                    + " WHERE action.Nom = @p1";
                cmd.Parameters.AddWithValue("p1", name);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Vaisseau = VR.GetLinkAction((int)r["ID"]);
                }
            }
            return u;
        }


        public Actions GetOne(int id)
        {
            Actions u = new Actions();
            VaisseauRepo VR = new VaisseauRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT action.ID, action.Nom"
                    + " FROM action"
                    + " WHERE action.id = @p1";
                cmd.Parameters.AddWithValue("p1", id);

                SqlDataReader r = cmd.ExecuteReader();
                if(r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Vaisseau = VR.GetLinkAction((int)r["ID"]);
                }
            }
            return u;
        }

        public IEnumerable<Actions> GetLinkVaisseau(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM action join detailactionvaisseau on detailactionvaisseau.XIDAction = action.ID"
                    + "  where detailactionvaisseau.XIDVaisseau = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Actions
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public void Update(int id, Actions T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_Action";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", T.Id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

