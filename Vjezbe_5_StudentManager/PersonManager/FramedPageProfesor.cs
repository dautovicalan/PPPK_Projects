using System.Windows.Controls;
using Zadatak.ViewModels;

namespace Zadatak
{

    public class FramedPageProfesor : Page
    {
        public FramedPageProfesor(ProfesorViewModel personViewModel)
        {
            PersonViewModel = personViewModel;
        }
        public ProfesorViewModel PersonViewModel { get; }
        public Frame Frame { get; set; }
    }
}
