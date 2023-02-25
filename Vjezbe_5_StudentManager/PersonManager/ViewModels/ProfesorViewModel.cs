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
    public class ProfesorViewModel
    {
        public ObservableCollection<Profesor> People { get; }
        public ProfesorViewModel()
        {
            People = new ObservableCollection<Profesor>(RepositoryFactory.GetRepository().GetProfesors());
            People.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddProfesor(People[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteProfesor(e.OldItems.OfType<Profesor>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateProfesor(e.NewItems.OfType<Profesor>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Profesor person) => People[People.IndexOf(person)] = person;
    }
}
