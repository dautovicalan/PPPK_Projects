using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zadatak.Models;
using Zadatak.ViewModels;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for ListProfesorPage.xaml
    /// </summary>
    public partial class ListProfesorPage : FramedPageProfesor
    {
        public ListProfesorPage(ProfesorViewModel profesorViewModel) : base(profesorViewModel)
        {
            InitializeComponent();
            LvPeople.ItemsSource = profesorViewModel.People;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditProfesorPage(PersonViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvPeople.SelectedItem != null)
            {
                Frame.Navigate(new EditProfesorPage(PersonViewModel, LvPeople.SelectedItem as Profesor) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvPeople.SelectedItem != null)
            {
                PersonViewModel.People.Remove(LvPeople.SelectedItem as Profesor);
            }
        }
    }
}
