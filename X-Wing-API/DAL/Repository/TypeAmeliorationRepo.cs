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
    public class TypeAmeliorationRepo : ITypeAmelioration<int, TypeAmelioration>
    {

        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";
        public void Create(TypeAmelioration T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_Type";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@pilote", T.XIDPilote);
                cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM typeamelioration WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<TypeAmelioration> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM typeamelioration";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new TypeAmelioration
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["id"]
                    };
                }
            }

        }

        public IEnumerable<ViewType> GetLinkPilote(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM typeamelioration"
                                 + " join detailpilotetypeamelioration on detailpilotetypeamelioration.XIDTypeAmelioration = typeamelioration.ID"
                                 + " join pilote on pilote.ID = detailpilotetypeamelioration.XIDPilote where pilote.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewType
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewType> GetLinkAmelioration(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM typeamelioration join amelioration"
                    +" on amelioration.XIDTypeAmelioration = typeamelioration.ID"
                    + "  where amelioration.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewType
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }


        public TypeAmelioration GetByName(string name)
        {
            TypeAmelioration u = new TypeAmelioration();
            AmeliorationRepo AR = new AmeliorationRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * from typeamelioration where typeamelioration.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", name);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Nom = r["Nom"].ToString();
                    u.Id = (int)r["ID"];
                    u.Amelioration = AR.GetByLinkType((int)r["ID"]);
                }
            }
            return u;
        }

        public TypeAmelioration GetOne(int id)
        {
            TypeAmelioration u = new TypeAmelioration();
            AmeliorationRepo AR = new AmeliorationRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * from typeamelioration where typeamelioration.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();
                    u.Nom = r["Nom"].ToString();
                    u.Id = (int)r["ID"];
                    u.Amelioration = AR.GetByLinkType((int)r["ID"]);
                }
            }
            return u;
        }

        public IEnumerable<ViewType> GetLinkCamp(int id)
        {
            VaisseauRepo VR = new VaisseauRepo();
            CampRepo CR = new CampRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT distinct typeamelioration.Nom, typeamelioration.ID FROM typeamelioration"
                    + " join detailpilotetypeamelioration on detailpilotetypeamelioration.XIDTypeamelioration = typeamelioration.Id"
                    + " join pilote on detailpilotetypeamelioration.XIDPilote = pilote.Id"
                    + " join camp on camp.ID = pilote.XIDCamp where camp.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewType
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public void Update(int id, TypeAmelioration T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_Action";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@pilote", T.XIDPilote);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
