using System.Windows.Controls;
using Zadatak.ViewModels;

namespace Zadatak
{

    public class FramedPage : Page
    {
        public FramedPage(StudentViewModel personViewModel)
        {
            PersonViewModel = personViewModel;
        }
        public StudentViewModel PersonViewModel { get; }
        public Frame Frame { get; set; }
    }
}
