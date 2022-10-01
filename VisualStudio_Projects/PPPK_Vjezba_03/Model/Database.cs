using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Vjezba_03.Model
{
    public class Database
    {
        public string Name { get; set; }
        public override string ToString() => Name;
    }

    public enum SQLStatement
    {
        SELECT,
        INSERT,
        UPDATE,
        DELETE
    }
}
