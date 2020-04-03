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
    public class EscadronRepo : IEscadron<int, Escadron>
    {

        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";
        public void Create(Escadron T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_escadron";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@Visible", T.Visible);
                cmd.Parameters.AddWithValue("@Points", T.Points);
                cmd.Parameters.AddWithValue("@Description", T.Description);
                cmd.Parameters.AddWithValue("@XIDCollection", T.XIDColllection);
                cmd.Parameters.AddWithValue("@User", T.XIDUser);
                cmd.Parameters.AddWithValue("@Camp", T.XIDCamp);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM escadron WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<ViewEscadron> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM escadron";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewEscadron
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["id"]
                    };
                }
            }

        }

        public Escadron GetByName(string name)
        {
            Escadron u = new Escadron();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            PiloteRepo PR = new PiloteRepo();
            VaisseauRepo VR = new VaisseauRepo();
            CollectionRepo CoR = new CollectionRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM escadron where escadron.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", name);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Nom = r["Nom"].ToString();
                    u.Id = (int)r["id"];
                    u.Visible = (bool)r["EstVisible"];
                    u.Points = (int)r["Points"];
                    u.Description = r["Description"].ToString();
                    u.Camp = CR.GetLinkEscadron((int)r["ID"]);
                    u.Vaisseau = VR.GetLinkEscadron((int)r["ID"]);
                    u.Pilote = PR.GetLinkEscadron((int)r["ID"]);
                    u.Amelioration = AR.GetLinkEscadron((int)r["ID"]);
                    u.Collection = CoR.GetLinkEscadron((int)r["ID"]);
                }
            }
            return u;
        }

        public IEnumerable<ViewEscadron> GetLinkCamp(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM escadron join camp on escadron.XIDCamp = camp.ID"
                    + "  where camp.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewEscadron
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewEscadron> GetLinkPilote(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM escadron join camp on escadron.XIDCamp = camp.ID"
                    + " join pilote on pilote.XIDCamp = camp.ID where pilote.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewEscadron
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewEscadron> GetLinkVaisseau(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM escadron join camp on escadron.XIDCamp = camp.ID"
                    + " join pilote on pilote.XIDCamp = camp.ID"
                    +"  join vaisseau on pilote.XIDVaisseau = vaisseau.ID where vaisseau.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewEscadron
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewEscadron> GetLinkCollection(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM escadron join collection on collection.ID = escadron.XIDCollection where collection.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewEscadron
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }


        public Escadron GetOne(int id)
        {
            Escadron u = new Escadron();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            PiloteRepo PR = new PiloteRepo();
            VaisseauRepo VR = new VaisseauRepo();
            CollectionRepo CoR = new CollectionRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM escadron where escadron.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Nom = r["Nom"].ToString();
                    u.Id = (int)r["id"];
                    u.Visible = (bool)r["EstVisible"];
                    u.Points = (int)r["Points"];
                    u.Description = r["Description"].ToString();
                    u.Camp = CR.GetLinkEscadron((int)r["ID"]);
                    u.Vaisseau = VR.GetLinkEscadron((int)r["ID"]);
                    u.Pilote = PR.GetLinkEscadron((int)r["ID"]);
                    u.Amelioration = AR.GetLinkEscadron((int)r["ID"]);
                    u.Collection = CoR.GetLinkEscadron((int)r["ID"]);
                }
            }
            return u;
        }

        public void Update(int id, Escadron T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_Escadron";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@Visible", T.Visible);
                cmd.Parameters.AddWithValue("@Points", T.Points);
                cmd.Parameters.AddWithValue("@Description", T.Description);
                cmd.Parameters.AddWithValue("@XIDCollection", T.XIDColllection);
                cmd.Parameters.AddWithValue("@User", T.XIDUser);
                cmd.Parameters.AddWithValue("@Camp", T.XIDCamp);
                cmd.ExecuteNonQuery();
            }
        }

        IEnumerable<Escadron> IRepository<int, Escadron>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
