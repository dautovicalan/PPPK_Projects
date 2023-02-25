using System.Windows;
using System.Windows.Controls;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame.Navigate(new ListPeoplePage(new ViewModels.StudentViewModel()) { Frame = Frame });
        }

        private void BtnStudents_Click(object sender, RoutedEventArgs e)
            => Frame.Navigate(new ListPeoplePage(new ViewModels.StudentViewModel()) { Frame = Frame });

        private void BtnProfesors_Click(object sender, RoutedEventArgs e)
            => Frame.Navigate(new ListProfesorPage(new ViewModels.ProfesorViewModel()) { Frame = Frame });

        private void BtnKolegij_Click(object sender, RoutedEventArgs e)
            => Frame.Navigate(new ListKolegijPage(new ViewModels.KolegijViewModel()) { Frame = Frame });
    }
}
