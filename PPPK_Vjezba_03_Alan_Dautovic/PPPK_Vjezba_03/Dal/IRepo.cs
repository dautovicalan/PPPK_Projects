using PPPK_Vjezba_03.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Vjezba_03.Dal
{
    public interface IRepo
    {
        void LogIn(string server, string username, string password);
        IEnumerable<Database> GetDatabases();
        DataSet RunQuery(string query, Database database);
        int RunNonQuery(string query, Database database);
    }
}
