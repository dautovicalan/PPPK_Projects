using System.Windows;
using System.Windows.Controls;
using Zadatak.Models;
using Zadatak.ViewModels;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for ListPersonsPage.xaml
    /// </summary>
    public partial class ListPeoplePage : FramedPage
    {
        public ListPeoplePage(StudentViewModel personViewModel) : base(personViewModel)
        {
            InitializeComponent();
            LvPeople.ItemsSource = personViewModel.People;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditPersonPage(PersonViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvPeople.SelectedItem != null)
            {
                Frame.Navigate(new EditPersonPage(PersonViewModel, LvPeople.SelectedItem as Student) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvPeople.SelectedItem != null)
            {
                PersonViewModel.People.Remove(LvPeople.SelectedItem as Student);
            }
        }
    }
}
