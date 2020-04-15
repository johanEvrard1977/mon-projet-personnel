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
    public class CollectionRepo : ICollectionRepo<int, Collection>
    {

        private string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=projetPerso;Integrated Security=True;Pooling=False";
        public void Create(Collection T)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SP_Add_Collection";
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable Vaisseaux = new DataTable();
                    Vaisseaux.Columns.Add(new DataColumn("XIDVaisseau", typeof(int)));
                    if (T.XIDVaisseau != null)
                    { 
                        foreach (int v in T.XIDVaisseau)
                        {
                            Vaisseaux.Rows.Add(v);
                        }
                        
                    }
                    SqlParameter vvaisseaux = new SqlParameter()
                    {
                        ParameterName = "@vaisseau",
                        Value = Vaisseaux,
                        TypeName = "multipleId"
                    };
                    cmd.Parameters.Add(vvaisseaux);

                    DataTable Pilotes = new DataTable();
                    Pilotes.Columns.Add(new DataColumn("XIDPilote", typeof(int)));
                    if (T.XIDPilote != null)
                    {
                        foreach (int p in T.XIDPilote)
                        {
                            Pilotes.Rows.Add(p);
                        }
                    }
                    SqlParameter ppilotes = new SqlParameter()
                    {
                        ParameterName = "@pilote",
                        Value = Pilotes,
                        TypeName = "multipleId"
                    };
                    cmd.Parameters.Add(ppilotes);


                    DataTable Ameliorations = new DataTable();
                    Ameliorations.Columns.Add(new DataColumn("XIDAmelioration", typeof(int)));
                    if (T.XIDAmelioration != null)
                    {
                        foreach (int a in T.XIDAmelioration)
                        {
                            Ameliorations.Rows.Add(a);
                        }
                    }
                    SqlParameter aameliorations = new SqlParameter()
                    {
                        ParameterName = "@amelioration",
                        Value = Ameliorations,
                        TypeName = "multipleId"
                    };
                    cmd.Parameters.Add(aameliorations);
                    cmd.Parameters.AddWithValue("@Name", T.Nom);
                    cmd.Parameters.AddWithValue("@user", T.XIDUser);
                    cmd.Parameters.AddWithValue("@camp", T.XIDCamp);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
        }

        public void InsertIntoCollection(Collection T)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SP_Add_Into_Collection";
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable Vaisseaux = new DataTable();
                    Vaisseaux.Columns.Add(new DataColumn("XIDVaisseau", typeof(int)));
                    if (T.XIDVaisseau != null)
                    {
                        foreach (int v in T.XIDVaisseau)
                        {
                            Vaisseaux.Rows.Add(v);
                        }

                    }
                    SqlParameter vvaisseaux = new SqlParameter()
                    {
                        ParameterName = "@vaisseau",
                        Value = Vaisseaux,
                        TypeName = "multipleId"
                    };
                    cmd.Parameters.Add(vvaisseaux);

                    DataTable Pilotes = new DataTable();
                    Pilotes.Columns.Add(new DataColumn("XIDPilote", typeof(int)));
                    if (T.XIDPilote != null)
                    {
                        foreach (int p in T.XIDPilote)
                        {
                            Pilotes.Rows.Add(p);
                        }
                    }
                    SqlParameter ppilotes = new SqlParameter()
                    {
                        ParameterName = "@pilote",
                        Value = Pilotes,
                        TypeName = "multipleId"
                    };
                    cmd.Parameters.Add(ppilotes);


                    DataTable Ameliorations = new DataTable();
                    Ameliorations.Columns.Add(new DataColumn("XIDAmelioration", typeof(int)));
                    if (T.XIDAmelioration != null)
                    {
                        foreach (int a in T.XIDAmelioration)
                        {
                            Ameliorations.Rows.Add(a);
                        }
                    }
                    SqlParameter aameliorations = new SqlParameter()
                    {
                        ParameterName = "@amelioration",
                        Value = Ameliorations,
                        TypeName = "multipleId"
                    };
                    cmd.Parameters.Add(aameliorations);
                    cmd.Parameters.AddWithValue("@collection", T.XIDCollection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM collection WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteIntoCollection(Collection T)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SP_Delete_Into_Collection";
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable Vaisseaux = new DataTable();
                    Vaisseaux.Columns.Add(new DataColumn("XIDVaisseau", typeof(int)));
                    if (T.XIDVaisseau != null)
                    {
                        foreach (int v in T.XIDVaisseau)
                        {
                            Vaisseaux.Rows.Add(v);
                        }

                    }
                    SqlParameter vvaisseaux = new SqlParameter()
                    {
                        ParameterName = "@vaisseau",
                        Value = Vaisseaux,
                        TypeName = "multipleId"
                    };
                    cmd.Parameters.Add(vvaisseaux);

                    DataTable Pilotes = new DataTable();
                    Pilotes.Columns.Add(new DataColumn("XIDPilote", typeof(int)));
                    if (T.XIDPilote != null)
                    {
                        foreach (int p in T.XIDPilote)
                        {
                            Pilotes.Rows.Add(p);
                        }
                    }
                    SqlParameter ppilotes = new SqlParameter()
                    {
                        ParameterName = "@pilote",
                        Value = Pilotes,
                        TypeName = "multipleId"
                    };
                    cmd.Parameters.Add(ppilotes);


                    DataTable Ameliorations = new DataTable();
                    Ameliorations.Columns.Add(new DataColumn("XIDAmelioration", typeof(int)));
                    if (T.XIDAmelioration != null)
                    {
                        foreach (int a in T.XIDAmelioration)
                        {
                            Ameliorations.Rows.Add(a);
                        }
                    }
                    SqlParameter aameliorations = new SqlParameter()
                    {
                        ParameterName = "@amelioration",
                        Value = Ameliorations,
                        TypeName = "multipleId"
                    };
                    cmd.Parameters.Add(aameliorations);
                    cmd.Parameters.AddWithValue("@collection", T.XIDCollection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }

        }

        public IEnumerable<ViewCollection> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM collection";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewCollection
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["id"]
                    };
                }
            }

        }

        public Collection GetByName(string name)
        {
            Collection u = new Collection();
            PiloteRepo PR = new PiloteRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            EscadronRepo ER = new EscadronRepo();
            VaisseauRepo VR = new VaisseauRepo();
            UserRepository UR = new UserRepository();
            CampRepo CR = new CampRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT collection.ID, collection.Nom"
                    + " FROM collection"
                    + " WHERE collection.Nom = @p1";
                cmd.Parameters.AddWithValue("p1", name);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Pilote = PR.GetLinkCollection((int)r["ID"]);
                    u.Vaisseau = VR.GetLinkCollection((int)r["ID"]);
                    u.Amelioration = AR.GetLinkCollection((int)r["ID"]);
                    u.Users = UR.GetLinkCollection((int)r["ID"]);
                    u.Camp = CR.GetLinkCollection((int)r["ID"]);
                    u.Escadrons = ER.GetByLinkCollection((int)r["ID"]);
                }
            }
            return u;
        }

        public IEnumerable<ViewCollection> GetByLinkUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM collection join Users"
                    + " on collection.XIDUsers = Users.UserId"
                    + " where Users.UserId = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewCollection
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public IEnumerable<ViewCollection> GetLinkEscadron(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM collection join escadron"
                    + " on collection.ID = escdaron.XIDCollection"
                    + " where escadron.ID = @p1";
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewCollection
                    {
                        Nom = r["Nom"].ToString(),
                        Id = (int)r["ID"]
                    };
                }
            }
        }

        public Collection GetOne(int id)
        {
            Collection u = new Collection();
            PiloteRepo PR = new PiloteRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            EscadronRepo ER = new EscadronRepo();
            VaisseauRepo VR = new VaisseauRepo();
            UserRepository UR = new UserRepository();
            CampRepo CR = new CampRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *"
                    + " FROM collection"
                    + " WHERE collection.id = @p1";
                cmd.Parameters.AddWithValue("p1", id);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Pilote = PR.GetLinkCollection((int)r["ID"]);
                    u.Vaisseau = VR.GetLinkCollection((int)r["ID"]);
                    u.Amelioration = AR.GetLinkCollection((int)r["ID"]);
                    u.Users = UR.GetLinkCollection((int)r["ID"]);
                    u.Camp = CR.GetLinkCollection((int)r["ID"]);
                    u.Escadrons = ER.GetByLinkCollection((int)r["ID"]);
                }
            }
            return u;
        }

        public void Update(int id, Collection T)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Update_Collection";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", T.Nom);
                cmd.Parameters.AddWithValue("@user", T.XIDUser);
                cmd.ExecuteNonQuery();
            }
        }

        IEnumerable<Collection> IRepository<int, Collection>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
