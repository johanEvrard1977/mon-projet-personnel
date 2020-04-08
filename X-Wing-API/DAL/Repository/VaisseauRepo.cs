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
    public class VaisseauRepo : IVaisseauxRepo<int, Vaisseaux>
    {

        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";
        public void Create(Vaisseaux T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_Vaisseau";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@valAgilite", T.ValeurAgilite);
                cmd.Parameters.AddWithValue("@valArmePrincipale", T.ValeurArmePrincipale);
                cmd.Parameters.AddWithValue("@ValBouclier", T.Bouclier);
                cmd.Parameters.AddWithValue("@PtsStructure", T.Structure);
                cmd.Parameters.AddWithValue("@ValEnergie", T.Energie);
                cmd.Parameters.AddWithValue("@Taille", T.Taille);
                cmd.Parameters.AddWithValue("@Capacite", T.Capacite);
                cmd.Parameters.AddWithValue("@Action", T.XIDAction);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM detailactionvaisseau WHERE XIDVaisseau = @param2";
                cmd.Parameters.AddWithValue("@param2", id);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM vaisseau WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<ViewVaisseau> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM vaisseau";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewVaisseau
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["id"]
                    };
                }
            }
         }

        public IEnumerable<ViewVaisseau> GetLinkAction(int id)
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
                    yield return new ViewVaisseau
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
         }

        public IEnumerable<ViewVaisseau> GetLinkCollection(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM vaisseau join detailvaisseaucollection on detailvaisseaucollection.XIDVaisseau = vaisseau.ID"
                    + "  where detailvaisseaucollection.XIDCollection = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewVaisseau
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }


        public IEnumerable<ViewVaisseau> GetLinkPilote(int id)
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
                    yield return new ViewVaisseau
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewVaisseau> GetLinkEscadron(int id)
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
                    yield return new ViewVaisseau
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewVaisseau> GetLinkCamp(int id)
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
                    yield return new ViewVaisseau
                    {
                        Nom = r["Nom"].ToString(),
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
                cmd.CommandText = "SELECT *"
                    + " FROM vaisseau"
                    + " WHERE vaisseau.Nom = @p1";
                cmd.Parameters.AddWithValue("p1", name);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Action = AR.GetLinkVaisseau((int)r["ID"]);
                    u.Pilote = PR.GetLinkVaisseau((int)r["ID"]);
                    u.Camp = CR.GetLinkVaisseau((int)r["ID"]);
                    u.Bouclier = (int)r["ValBouclier"];
                    u.ValeurAgilite = (int)r["ValAgilite"];
                    u.ValeurArmePrincipale = (int)r["ValArmePrincipale"];
                    u.Structure = (int)r["PtsStructure"];
                    u.Energie = (int)r["ValEnergie"];
                    u.Taille = r["Taille"].ToString();
                    u.Capacite = r["Capacite"].ToString();
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
                cmd.CommandText = "SELECT *"
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
                    u.Bouclier = (int)r["ValBouclier"];
                    u.ValeurAgilite = (int)r["ValAgilite"];
                    u.ValeurArmePrincipale = (int)r["ValArmePrincipale"];
                    u.Structure = (int)r["PtsStructure"];
                    u.Energie = (int)r["ValEnergie"];
                    u.Taille = r["Taille"].ToString();
                    u.Capacite = r["Capacite"].ToString() ;
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
                cmd.CommandText = "SP_Update_Vaisseau";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@valAgilite", T.ValeurAgilite);
                cmd.Parameters.AddWithValue("@valArmePrincipale", T.ValeurArmePrincipale);
                cmd.Parameters.AddWithValue("@ValBouclier", T.Bouclier);
                cmd.Parameters.AddWithValue("@PtsStructure", T.Structure);
                cmd.Parameters.AddWithValue("@ValEnergie", T.Energie);
                cmd.Parameters.AddWithValue("@Taille", T.Taille);
                cmd.Parameters.AddWithValue("@Capacite", T.Capacite);
                cmd.Parameters.AddWithValue("@Action", T.XIDAction);
                cmd.ExecuteNonQuery();
            }
        }

        IEnumerable<Vaisseaux> IRepository<int, Vaisseaux>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
