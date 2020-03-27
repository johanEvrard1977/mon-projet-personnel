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
    public class PiloteRepo : IPiloteRepo<int, Pilote>
    {

        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";
        public void Create(Pilote T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_Pilote";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@Unique", T.Unique);
                cmd.Parameters.AddWithValue("@Cout", T.Cout);
                cmd.Parameters.AddWithValue("@VP", T.ValeurPilotage);
                cmd.Parameters.AddWithValue("@Com", T.Commentaires);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM pilote WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<Pilote> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Pilote
                    {
                        Nom = r["Nom"].ToString(),
                        Unique = (bool) r["EstUnique"],
                        Cout = (int)r["Cout"],
                        ValeurPilotage = (int)r["ValPilotage"],
                        Commentaires = r["Commentaire"].ToString(),
                        Id = (int)r["id"]
                    };
                }
            }

        }

        public Pilote GetByName(string name)
        {
            Pilote u = new Pilote();
            VaisseauRepo VR = new VaisseauRepo();
            TypeAmeliorationRepo TA = new TypeAmeliorationRepo();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *"
                    + " FROM pilote"
                    + " WHERE pilote.id = @p1";
                cmd.Parameters.AddWithValue("p1", name);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Vaisseaux = VR.GetLinkPilote((int)r["ID"]);
                    u.Camp = CR.GetLinkPilote((int)r["ID"]);
                    u.Amelioration = AR.GetLinkPilote((int)r["ID"]);
                    u.Commentaires = r["Commentaire"].ToString();
                }
                return u;
            }
        }

        public IEnumerable<Pilote> GetLinkVaisseau(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote join vaisseau on pilote.XIDVaisseau = vaisseau.ID"
                    + "  where vaisseau.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Pilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"],
                        Commentaires = r["Commentaire"].ToString(),
                        Cout = (int)r["Cout"],
                    };
                }
            }
        }

        public IEnumerable<Pilote> GetLinkPilote(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote join vaisseau on pilote.XIDVaisseau = vaisseau.ID"
                    + "  where pilote.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Pilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"],
                        Cout = (int)r["Cout"],
                        Unique = (bool)r["ID"],
                        Commentaires = r["Commentaires"].ToString(),
                        ValeurPilotage = (int)r["ValPilotage"]
                    };
                }
            }
        }

        public IEnumerable<Pilote> GetLinkCamp(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote"
                    + " join camp on camp.ID = pilote.XIDCamp where camp.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Pilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"],
                        Cout = (int)r["Cout"],
                        Commentaires = r["Commentaire"].ToString(),
                        ValeurPilotage = (int)r["ValPilotage"]
                    };
                }
            }
        }

        public IEnumerable<Pilote> GetLinkAmelioration(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote join detailpilotetypeamelioration"
                    + " on detailpilotetypeamelioration.XIDPilote = pilote.ID"
                    + " join typeamelioration on detailpilotetypeamelioration.XIDTypeAmelioration"
                    + " join amelioration on amelioration.ID = detailepiloteamelioration.XIDAmelioration"
                    + " where amelioration.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Pilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"],
                        Cout = (int)r["Cout"],
                        Unique = (bool)r["ID"],
                        Commentaires = r["Commentaires"].ToString(),
                        ValeurPilotage = (int)r["ValPilotage"]
                    };
                }
            }
        }

        public IEnumerable<Pilote> GetLinkEscadron(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote join camp on camp.ID = pilote.XIDCamp"
                    +" join escadron on escadron.XIDCamp = camp.ID"
                    + " where escadron.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Pilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"],
                        Cout = (int)r["Cout"],
                        Unique = (bool)r["ID"],
                        Commentaires = r["Commentaires"].ToString(),
                        ValeurPilotage = (int)r["ValPilotage"]
                    };
                }
            }
        }


        public Pilote GetOne(int id)
        {
            Pilote u = new Pilote();
            VaisseauRepo VR = new VaisseauRepo();
            TypeAmeliorationRepo TA = new TypeAmeliorationRepo();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *"
                    + " FROM pilote"
                    + " WHERE pilote.id = @p1";
                cmd.Parameters.AddWithValue("p1", id);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Vaisseaux = VR.GetLinkPilote((int)r["ID"]);
                    u.Camp = CR.GetLinkPilote((int)r["ID"]);
                    u.Amelioration = AR.GetLinkPilote((int)r["ID"]);
                    u.Commentaires = r["Commentaire"].ToString();
                }
            }
            return u;
        }

        public void Update(int id, Pilote T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_Pilote";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", T.Id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@Unique", T.Unique);
                cmd.Parameters.AddWithValue("@Cout", T.Cout);
                cmd.Parameters.AddWithValue("@VP", T.ValeurPilotage);
                cmd.Parameters.AddWithValue("@Com", T.Commentaires);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
