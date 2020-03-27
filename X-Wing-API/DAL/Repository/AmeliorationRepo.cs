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
                cmd.CommandText = "DELETE FROM amelioration WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<Amelioration> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM amelioration";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Amelioration
                    {
                        Id = (int)r["ID"],
                        Nom = r["amelioration"].ToString(),
                        Cout = (int)r["Cout"],
                        UnParVaisseau = (bool)r["UnSeulExemplaireParVaisseau"],
                        Unique = (bool)r["PersonnageUniqueConcerne"],
                        TailleMin = (int)r["TailleMinAutorisee"],
                        TailleMax = (int)r["TailleMaxAutorisee"],
                        Description = r["Description"].ToString()
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
                cmd.CommandText = "SELECT amelioration.ID, amelioration.Cout as Cout , Description, UnSeulExemplaireParVaisseau, TailleMinAutorisee, TailleMaxAutorisee"
                    + " PersonnageUniqueConcerne, pilote.ID as pId, typeamelioration.ID as tId, amelioration.Nom as 'amelioration'"
                    + " FROM amelioration join typeamelioration on XIDTypeAmelioration = amelioration.ID"
                    + " join detailpilotetypeamelioration on detailpilotetypeamelioration.XIDTypeAmelioration = amelioration.ID"
                    + " join pilote on detailpilotetypeamelioration.XIDPilote = pilote.ID where amelioration.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Id = (int)r["ID"];
                    u.Nom = r["amelioration"].ToString();
                    u.Cout = (int)r["Cout"];
                    u.UnParVaisseau = (bool) r["UnSeulExemplaireParVaisseau"];
                    u.Unique = (bool)r["PersonnageUniqueConcerne"];
                    u.TailleMin = (int)r["TailleMinAutorisee"];
                    u.TailleMax = (int)r["TailleMaxAutorisee"];
                    u.Description = r["Description"].ToString();
                    u.Type = TR.GetLinkAmelioration((int)r["tId"]);
                    u.Pilote = PR.GetLinkAmelioration((int)r["pId"]);
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
                cmd.CommandText = "SELECT amelioration.ID, Cout, Description, UnSeulExemplaireParVaisseau, TailleMinAutorisee, TailleMaxAutorisee"
                    + "PersonnageUniqueConcerne, pilote.ID as pId, typeamelioration.ID as tId amelioration.Nom as 'amelioration', vaisseau.Nom as 'vaisseau'"
                    + " FROM amelioration join typeamelioration on XIDTypeAmelioration = amelioration.ID"
                    + " join detailpilotetypeamelioration on detailpilotetypeamelioration.XIDAmelioration = amelioration.ID"
                    + " join pilote on detailpilotetypeamelioration.XIDPilote = pilote.ID where amelioration.Nom = @p1";
                cmd.Parameters.AddWithValue("@p1", name);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Id = (int)r["ID"];
                    u.Nom = r["amelioration"].ToString();
                    u.Cout = (int)r["Cout"];
                    u.UnParVaisseau = (bool)r["UnSeulExemplaireParVaisseau"];
                    u.Unique = (bool)r["PersonnageUniqueConcerne"];
                    u.TailleMin = (int)r["TailleMinAutorisee"];
                    u.TailleMax = (int)r["TailleMaxAutorisee"];
                    u.Description = r["Description"].ToString();
                    u.Type = TR.GetLinkAmelioration((int)r["tId"]);
                    u.Pilote = PR.GetLinkAmelioration((int)r["pId"]);
                }
            }
            return u;
        }

        public IEnumerable<Amelioration> GetLinkEscadron(int id)
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
                    yield return new Amelioration
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }


        public IEnumerable<Amelioration> GetLinkPilote(int id)
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
                    yield return new Amelioration
                    {
                        Nom = r["Nom"].ToString(),
                        Cout = (int)r["Cout"],
                        Description= r["Description"].ToString(),
                        Unique = (bool)r["Unique"],
                        UnParVaisseau = (bool)r["UnSeulExemplaireParVaisseau"],
                        TailleMax = (int)r["TailleMax"],
                        TailleMin = (int)r["TailleMin"],
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<Amelioration> GetByLinkType(int id)
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
                    yield return new Amelioration
                    {
                        Nom = r["Nom"].ToString(),
                        Cout = (int)r["Cout"],
                        Description = r["Description"].ToString(),
                        Unique = (bool)r["Unique"],
                        UnParVaisseau = (bool)r["UnSeulExemplaireParVaisseau"],
                        TailleMax = (int)r["TailleMax"],
                        TailleMin = (int)r["TailleMin"],
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
                cmd.Parameters.AddWithValue("@id", T.Id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
