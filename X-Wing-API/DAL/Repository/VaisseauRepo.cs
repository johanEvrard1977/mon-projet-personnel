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
    public class VaisseauRepo : IVaisseauxRepo<int, Vaisseaux>
    {

        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";
        public void Create(Vaisseaux T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_Vaisseaux";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@VA", T.ValeurAgilite);
                cmd.Parameters.AddWithValue("@VAP", T.ValeurArmePrincipale);
                cmd.Parameters.AddWithValue("@Bouclier", T.Bouclier);
                cmd.Parameters.AddWithValue("@Structure", T.Structure);
                cmd.Parameters.AddWithValue("@Energie", T.Energie);
                cmd.Parameters.AddWithValue("@Taile", T.Taille);
                cmd.Parameters.AddWithValue("@Capacite", T.Capacite);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM vaisseau WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<Vaisseaux> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM vaisseau";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Vaisseaux
                    {
                        Nom = r["Nom"].ToString(),
                        ValeurAgilite = (int)r["ValAgilite"],
                        ValeurArmePrincipale = (int)r["ValArmePrincipale"],
                        Bouclier = (int)r["ValBouclier"],
                        Structure = (int)r["PtsStructure"],
                        Energie = (int)r["ValEnergie"],
                        Taille = r["Taille"].ToString(),
                        Capacite = r["Capacite"].ToString(),
                        Id = (int)r["id"]
                    };
                }
            }
         }

        public IEnumerable<Vaisseaux> GetLinkAction(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM vaisseau join detailactionvaisseau on detailactionvaisseau.XIDVaisseau = vaisseau.ID"
                    + "  where detailactionvaisseau.XIDAction = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Vaisseaux
                    {
                        Nom = r["Nom"].ToString(),
                        ValeurAgilite = (int)r["ValAgilite"],
                        ValeurArmePrincipale = (int)r["ValArmePrincipale"],
                        Bouclier = (int)r["ValBouclier"],
                        Structure = (int)r["PtsStructure"],
                        Energie = (int)r["ValEnergie"],
                        Taille = r["Taille"].ToString(),
                        Capacite = r["Capacite"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
         }

        public IEnumerable<Vaisseaux> GetLinkPilote(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM vaisseau join pilote on pilote.XIDVaisseau = vaisseau.ID"
                    + "  where pilote.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Vaisseaux
                    {
                        Nom = r["Nom"].ToString(),
                        ValeurAgilite = (int)r["ValAgilite"],
                        ValeurArmePrincipale = (int)r["ValArmePrincipale"],
                        Bouclier = (int)r["ValBouclier"],
                        Structure = (int)r["PtsStructure"],
                        Energie = (int)r["ValEnergie"],
                        Taille = r["Taille"].ToString(),
                        Capacite = r["Capacite"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<Vaisseaux> GetLinkEscadron(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM vaisseau join detailescadronvaisseau"
                    + " on detailescadronvaisseau.XIDVaisseau = vaisseau.ID join escadron"
                    + " on escadron.ID = detailescadronvaisseau.XIDEscadron"
                    + " where escadron.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Vaisseaux
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<Vaisseaux> GetLinkCamp(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM vaisseau join pilote on pilote.XIDVaisseau = vaisseau.ID"
                    + " join camp on camp.ID = pilote.XIDCamp where camp.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Vaisseaux
                    {
                        Nom = r["Nom"].ToString(),
                        ValeurAgilite = (int)r["ValAgilite"],
                        ValeurArmePrincipale = (int)r["ValArmePrincipale"],
                        Bouclier = (int)r["ValBouclier"],
                        Structure = (int)r["PtsStructure"],
                        Energie = (int)r["ValEnergie"],
                        Taille = r["Taille"].ToString(),
                        Capacite = r["Capacite"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public Vaisseaux GetByName(string name)
        {
            Vaisseaux u = new Vaisseaux();
            CampRepo CR = new CampRepo();
            PiloteRepo PR = new PiloteRepo();
            ActionRepo AR = new ActionRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT vaisseau.ID, vaisseau.Nom"
                    + " FROM vaisseau"
                    + " WHERE vaisseau.id = @p1";
                cmd.Parameters.AddWithValue("p1", name);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Action = AR.GetLinkVaisseau((int)r["ID"]);
                    u.Pilote = PR.GetLinkVaisseau((int)r["ID"]);
                    u.Camp = CR.GetLinkVaisseau((int)r["ID"]);
                }
            }
            return u;
        }


        public Vaisseaux GetOne(int id)
        {
            Vaisseaux u = new Vaisseaux();
            CampRepo CR = new CampRepo();
            PiloteRepo PR = new PiloteRepo();
            ActionRepo AR = new ActionRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT vaisseau.ID, vaisseau.Nom"
                    + " FROM vaisseau"
                    + " WHERE vaisseau.id = @p1";
                cmd.Parameters.AddWithValue("p1", id);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Action = AR.GetLinkVaisseau((int)r["ID"]);
                    u.Pilote = PR.GetLinkVaisseau((int)r["ID"]);
                    u.Camp = CR.GetLinkVaisseau((int)r["ID"]);
                }
            }
            return u;
        }

        public void Update(int id, Vaisseaux T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_Vaisseaux";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", T.Id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@VA", T.ValeurAgilite);
                cmd.Parameters.AddWithValue("@VAP", T.ValeurArmePrincipale);
                cmd.Parameters.AddWithValue("@Bouclier", T.Bouclier);
                cmd.Parameters.AddWithValue("@Structure", T.Structure);
                cmd.Parameters.AddWithValue("@Energie", T.Energie);
                cmd.Parameters.AddWithValue("@Taile", T.Taille);
                cmd.Parameters.AddWithValue("@Capacite", T.Capacite);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
