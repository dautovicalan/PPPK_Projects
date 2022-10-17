using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Vjezba_05.Dal
{
    // https://www.codeguru.com/dotnet/windows-presentation-foundations-observablecollection-made-easy/
    public interface IRepo
    {
        ObservableCollection<string> GetStudents();
        ObservableCollection<string> GetProfessors();
        ObservableCollection<string> GetSubjects();
    }
}
