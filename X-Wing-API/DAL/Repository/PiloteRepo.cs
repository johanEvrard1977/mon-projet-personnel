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
                cmd.Parameters.AddWithValue("@ValPil", T.ValeurPilotage);
                cmd.Parameters.AddWithValue("@Com", T.Commentaires);
                cmd.Parameters.AddWithValue("@Camp", T.XIDCamp);
                cmd.Parameters.AddWithValue("@Vaisseau", T.XIDVaisseau);
                cmd.Parameters.AddWithValue("@type", T.XIDType);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM detailpilotetypeamelioration WHERE XIDPilote = @param2";
                cmd.Parameters.AddWithValue("@param2", id);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM pilote WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<ViewPilote> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewPilote
                    {
                        Id = (int)r["ID"],
                        Nom = r["Nom"].ToString()
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
                    + " WHERE pilote.Nom = @p1";
                cmd.Parameters.AddWithValue("@p1", name);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Vaisseaux = VR.GetLinkPilote((int)r["ID"]);
                    u.Camp = CR.GetLinkPilote((int)r["ID"]);
                    u.Amelioration = AR.GetLinkPilote((int)r["ID"]);
                    u.Commentaires = r["Commentaire"].ToString();
                    u.Cout = (int)r["Cout"];
                    u.Unique = (bool)r["EstUnique"];
                    u.ValeurPilotage = (int)r["ValPilotage"];
                }
                return u;
            }
        }

        public IEnumerable<ViewPilote> GetLinkVaisseau(int id)
        {
            VaisseauRepo VR = new VaisseauRepo();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote join vaisseau on pilote.XIDVaisseau = vaisseau.ID"
                    + " where vaisseau.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewPilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }


        public IEnumerable<ViewPilote> GetLinkCollection(int id)
        {
            VaisseauRepo VR = new VaisseauRepo();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote join detailpilotecollection"
                    + " on pilote.ID = detailpilotecollection.XIDPilote join collection"
                    + " on collection.ID = detailpilotecollection.XIDCollection"
                    + " where pilote.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewPilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }


        public IEnumerable<ViewPilote> GetLinkCamp(int id)
        {
            VaisseauRepo VR = new VaisseauRepo();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
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
                    yield return new ViewPilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewPilote> GetLinkAmelioration(int id)
        {
            VaisseauRepo VR = new VaisseauRepo();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pilote join detailpilotetypeamelioration"
                                + " on detailpilotetypeamelioration.XIDPilote = pilote.ID"
                                + " join typeamelioration on detailpilotetypeamelioration.XIDTypeAmelioration = typeamelioration.ID"
                                + " join amelioration on amelioration.XIDTypeAmelioration = typeamelioration.ID"
                                + " where amelioration.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewPilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewPilote> GetLinkEscadron(int id)
        {
            VaisseauRepo VR = new VaisseauRepo();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
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
                    yield return new ViewPilote
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
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
                cmd.Parameters.AddWithValue("@p1", id);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Vaisseaux = VR.GetLinkPilote((int)r["ID"]);
                    u.Camp = CR.GetLinkPilote((int)r["ID"]);
                    u.Amelioration = AR.GetLinkPilote((int)r["ID"]);
                    u.Commentaires = r["Commentaire"].ToString();
                    u.Cout = (int)r["Cout"];
                    u.Unique = (bool)r["EstUnique"];
                    u.ValeurPilotage = (int)r["ValPilotage"];
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
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@Unique", T.Unique);
                cmd.Parameters.AddWithValue("@Cout", T.Cout);
                cmd.Parameters.AddWithValue("@ValPil", T.ValeurPilotage);
                cmd.Parameters.AddWithValue("@Com", T.Commentaires);
                cmd.Parameters.AddWithValue("@Camp", T.XIDCamp);
                cmd.Parameters.AddWithValue("@Vaisseau", T.XIDVaisseau);
                cmd.Parameters.AddWithValue("@type", T.XIDType);
                cmd.ExecuteNonQuery();
            }
        }

        IEnumerable<Pilote> IRepository<int, Pilote>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
