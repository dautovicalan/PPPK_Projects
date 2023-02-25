using System.Windows.Controls;
using Zadatak.ViewModels;

namespace Zadatak
{

    public class FramedPageKolegij : Page
    {
        public FramedPageKolegij(KolegijViewModel kolegijViewModel)
        {
            KolegijViewModel = kolegijViewModel;
        }
        public KolegijViewModel KolegijViewModel { get; }
        public Frame Frame { get; set; }
    }
}
