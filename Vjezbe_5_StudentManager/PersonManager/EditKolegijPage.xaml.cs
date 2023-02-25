using Microsoft.Win32;
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
using Zadatak.Dal;
using Zadatak.Models;
using Zadatak.Utils;
using Zadatak.ViewModels;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for EditKolegijPage.xaml
    /// </summary>
    public partial class EditKolegijPage : FramedPageKolegij
    {
        private readonly Kolegij kolegij;
        public EditKolegijPage(KolegijViewModel kolegijViewModel, Kolegij kolegij= null) : base(kolegijViewModel)
        {
            InitializeComponent();
            this.kolegij = kolegij ?? new Kolegij();
            CbProfesors.ItemsSource = RepositoryFactory.GetRepository().GetProfesors();
            
            if (kolegij != null)
                CbProfesors.SelectedItem = CbProfesors.ItemsSource.Cast<Profesor>().FirstOrDefault(x => x.IDProfesor == kolegij.ProfesorID);
            DataContext = kolegij;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {                
                kolegij.KolegijName = TbKolegijName.Text.Trim();
                kolegij.ProfesorID = ((Profesor)CbProfesors.SelectedItem).IDProfesor;
                if (kolegij.IDKolegij == 0)
                {
                    KolegijViewModel.Kolegij.Add(kolegij);
                }
                else
                {
                    KolegijViewModel.Update(kolegij);
                }
                Frame.NavigationService.GoBack();
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            if (CbProfesors.SelectedItem == null)
            {
                valid = false;
            }
            return valid;
        }
    }
}
