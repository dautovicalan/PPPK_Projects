using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Vjezba_03.Dal
{
    public static class RepoFactory
    {
        private static readonly Lazy<IRepo> repo = new Lazy<IRepo>(() => new Repository());
        public static IRepo GetRepository() => repo.Value;
    }
}
