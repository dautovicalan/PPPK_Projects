using PPPK_Vjezba_03.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PPPK_Vjezba_03.Dal
{
    public class Repository : IRepo
    {
        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string SelectDatabases = "SELECT name As Name FROM sys.databases";
        private static string cs;
        public IEnumerable<Database> GetDatabases()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = SelectDatabases;
                    cmd.CommandType = System.Data.CommandType.Text;                      
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Database
                            {
                                Name = dr[nameof(Database.Name)].ToString()
                            };
                        }
                    }
                }
            }
        }

        public void LogIn(string server, string username, string password)
        {
            string css = string.Format(ConnectionString, server, username, password);
            using (SqlConnection con = new SqlConnection(css))
            {
                con.Open();
                cs = css;
            }                        
        }

        public DataSet RunQuery(string query, Database database)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.ChangeDatabase(database.Name);
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {                    
                    DataSet ds = new DataSet();                    
                    da.Fill(ds, database.Name);
                    return ds;
                }
            }
            
        }
        public int RunNonQuery(string query, Database database)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                con.ChangeDatabase(database.Name);
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
