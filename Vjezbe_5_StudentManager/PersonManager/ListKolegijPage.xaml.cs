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
    /// Interaction logic for ListKolegijPage.xaml
    /// </summary>
    public partial class ListKolegijPage : FramedPageKolegij
    {
        public ListKolegijPage(KolegijViewModel kolegijViewModel) : base(kolegijViewModel)
        {
            InitializeComponent();
            LvKolegij.ItemsSource = kolegijViewModel.Kolegij;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditKolegijPage(KolegijViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvKolegij.SelectedItem != null)
            {
                Frame.Navigate(new EditKolegijPage(KolegijViewModel, LvKolegij.SelectedItem as Kolegij) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvKolegij.SelectedItem != null)
            {
                KolegijViewModel.Kolegij.Remove(LvKolegij.SelectedItem as Kolegij);
            }
        }

    }
}
