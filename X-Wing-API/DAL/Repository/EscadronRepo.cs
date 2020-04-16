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
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SP_Add_Escadron";
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
                    cmd.Parameters.AddWithValue("@collection", T.XIDCollection);
                    cmd.Parameters.AddWithValue("@camp", T.XIDCamp);
                    cmd.Parameters.AddWithValue("@estVisible", true);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
        }

        public void InsertIntoCollection(Escadron T)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SP_Add_Into_Escadron";
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
                    cmd.Parameters.AddWithValue("@escadron", T.XIDEscadron);
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
                cmd.CommandText = "DELETE FROM escadron WHERE id = @param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteIntoEscadron(Escadron T)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SP_Delete_Into_Escadron";
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
                    cmd.Parameters.AddWithValue("@escadron", T.XIDEscadron);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
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

        public IEnumerable<ViewEscadron> GetLinkCollection(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *"
                    + " FROM escadron e join collection co"
                    + " on co.ID = e.XIDCollection"
                    + " where co.ID = @p1";
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

        public Escadron GetByName(string name)
        {
            Escadron u = new Escadron();
            PiloteRepo PR = new PiloteRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            EscadronRepo ER = new EscadronRepo();
            VaisseauRepo VR = new VaisseauRepo();
            CollectionRepo CR = new CollectionRepo();
            CampRepo CaR = new CampRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT escadron.ID, escadron.Nom"
                    + " FROM ecadron"
                    + " WHERE escadron.Nom = @p1";
                cmd.Parameters.AddWithValue("p1", name);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Pilote = PR.GetLinkEscadron((int)r["ID"]);
                    u.Vaisseau = VR.GetLinkEscadron((int)r["ID"]);
                    u.Amelioration = AR.GetLinkEscadron((int)r["ID"]);
                    u.Camp = CaR.GetLinkEscadron((int)r["ID"]);
                }
            }
            return u;
        }

        public IEnumerable<ViewEscadron> GetByLinkCollection(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM escadron e join collection c"
                    + " on e.XIDCollection = c.ID"
                    + " where c.ID = @p1";
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
            PiloteRepo PR = new PiloteRepo();
            AmeliorationRepo AR = new AmeliorationRepo();
            CollectionRepo ER = new CollectionRepo();
            VaisseauRepo VR = new VaisseauRepo();
            UserRepository UR = new UserRepository();
            CampRepo CR = new CampRepo();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *"
                    + " FROM escadron e"
                    + " WHERE e.ID = @p1";
                cmd.Parameters.AddWithValue("p1", id);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    u.Id = (int)r["ID"];
                    u.Nom = r["Nom"].ToString();
                    u.Pilote = PR.GetLinkEscadron((int)r["ID"]);
                    u.Vaisseau = VR.GetLinkEscadron((int)r["ID"]);
                    u.Amelioration = AR.GetLinkEscadron((int)r["ID"]);
                    u.Camp = CR.GetLinkEscadron((int)r["ID"]);
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
                cmd.Parameters.AddWithValue("@collection", T.XIDCollection);
                cmd.ExecuteNonQuery();
            }
        }

        IEnumerable<Escadron> IRepository<int, Escadron>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
