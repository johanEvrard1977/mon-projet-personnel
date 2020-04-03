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
    public class AmeliorationRepo : IAmeliorationRepo<int, Amelioration>
    {

        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";
        public void Create(Amelioration T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_Amelioration";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@XIDType", T.XIDType);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@Cout", T.Cout);
                cmd.Parameters.AddWithValue("@seul", T.UnParVaisseau);
                cmd.Parameters.AddWithValue("@min", T.TailleMax);
                cmd.Parameters.AddWithValue("@max", T.TailleMin);
                cmd.Parameters.AddWithValue("@Desc", T.Description);
                cmd.Parameters.AddWithValue("@UniqueConcerne", T.Unique);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM amelioration WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<ViewAmelioration> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM amelioration";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewAmelioration
                    {
                        Id = (int)r["ID"],
                        Nom = r["Nom"].ToString()
                };
                }
            }
        }

        public Amelioration GetOne(int id)
        {
            Amelioration u = new Amelioration();
            TypeAmeliorationRepo TR = new TypeAmeliorationRepo();
            PiloteRepo PR = new PiloteRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * from amelioration where amelioration.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Cout = (int)r["Cout"];
                    u.UnParVaisseau = (bool) r["UnSeulExemplaireParVaisseau"];
                    u.Unique = (bool)r["PersonnageUniqueConcerne"];
                    u.TailleMin = r["TailleMinAutorisee"].ToString();
                    u.TailleMax = r["TailleMaxAutorisee"].ToString();
                    u.Description = r["Description"].ToString();
                    u.XIDType = (int)r["XIDTypeAmelioration"];
                    u.Type = TR.GetLinkAmelioration((int)r["ID"]);
                    u.Pilote = PR.GetLinkAmelioration((int)r["ID"]);
                }
            }
            return u;
        }

        public Amelioration GetByName(string name)
        {
            Amelioration u = new Amelioration();
            TypeAmeliorationRepo TR = new TypeAmeliorationRepo();
            PiloteRepo PR = new PiloteRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * from amelioration where amelioration.Nom = @p1";
                cmd.Parameters.AddWithValue("@p1", name);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Cout = (int)r["Cout"];
                    u.UnParVaisseau = (bool)r["UnSeulExemplaireParVaisseau"];
                    u.Unique = (bool)r["PersonnageUniqueConcerne"];
                    u.TailleMin = r["TailleMinAutorisee"].ToString();
                    u.TailleMax = r["TailleMaxAutorisee"].ToString();
                    u.Description = r["Description"].ToString();
                    u.Type = TR.GetLinkAmelioration((int)r["ID"]);
                    u.Pilote = PR.GetLinkAmelioration((int)r["ID"]);
                }
            }
            return u;
        }

        public IEnumerable<ViewAmelioration> GetLinkEscadron(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM amelioration join detailescadronamelioration"
                    + " on detailescadronamelioration.XIDAmelioration = amelioration.ID join escadron"
                    + " on escadron.ID = detailescadronamelioration.XIDEscadron"
                    + " where escadron.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewAmelioration
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewAmelioration> GetLinkCollection(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM amelioration join detailameliorationcollection"
                    + " on detailameliorationcollection.XIDAmelioration = amelioration.ID join collection"
                    + " on collection.ID = detailameliorationcollection.XIDCollection"
                    + " where collection.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewAmelioration
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }


        public IEnumerable<ViewAmelioration> GetLinkPilote(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM amelioration"
                                 + " join typeamelioration on typeamelioration.ID = amelioration.XIDTypeAmelioration"
                                 + " join detailpilotetypeamelioration on detailpilotetypeamelioration.XIDTypeAmelioration = typeamelioration.ID"
                                 + " join pilote on pilote.ID = detailpilotetypeamelioration.XIDPilote where pilote.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewAmelioration
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewAmelioration> GetByLinkType(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM amelioration join typeamelioration"
                    + " on amelioration.XIDTypeAmelioration = typeamelioration.ID"
                    + " where typeamelioration.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewAmelioration
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }


        public void Update(int id, Amelioration T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_amelioration";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@XIDType", T.XIDType);
                cmd.Parameters.AddWithValue("@UniqueConcerne", T.Unique);
                cmd.Parameters.AddWithValue("@seul", T.UnParVaisseau);
                cmd.Parameters.AddWithValue("@max", T.TailleMax);
                cmd.Parameters.AddWithValue("@min", T.TailleMin);
                cmd.Parameters.AddWithValue("@Cout", T.Cout);
                cmd.Parameters.AddWithValue("@desc", T.Description);
                cmd.ExecuteNonQuery();
            }
        }

        IEnumerable<Amelioration> IRepository<int, Amelioration>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
