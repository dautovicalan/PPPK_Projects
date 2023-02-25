using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Dal;
using Zadatak.Models;

namespace Zadatak.ViewModels
{
    public class KolegijViewModel
    {
        public ObservableCollection<Kolegij> Kolegij { get; }
        public KolegijViewModel()
        {
            Kolegij = new ObservableCollection<Kolegij>(RepositoryFactory.GetRepository().GetKolegijs());
            Kolegij.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddKolegij(Kolegij[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteKolegij(e.OldItems.OfType<Kolegij>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateKolegij(e.NewItems.OfType<Kolegij>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Kolegij person) => Kolegij[Kolegij.IndexOf(person)] = person;
    }
}
