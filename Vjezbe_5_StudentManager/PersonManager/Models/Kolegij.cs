using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.Models
{
    public class Kolegij
    {
        public int IDKolegij { get; set; }
        public string KolegijName { get; set; }
        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }
    }
}
