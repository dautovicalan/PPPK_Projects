using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Vjezba_03.Dal
{
    public static class RepoFactory
    {
        public static IRepo GetRepository() => new Repository();
    }
}
