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
    public class StudentViewModel
    {
        public ObservableCollection<Student> People { get; }
        public StudentViewModel()
        {
            People = new ObservableCollection<Student>(RepositoryFactory.GetRepository().GetStudents());
            People.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddStudent(People[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteStudent(e.OldItems.OfType<Student>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateStudent(e.NewItems.OfType<Student>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Student person) => People[People.IndexOf(person)] = person;
    }
}
