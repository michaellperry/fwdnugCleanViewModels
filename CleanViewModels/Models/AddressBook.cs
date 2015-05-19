using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assisticant.Collections;

namespace CleanViewModels.Models
{
    public class AddressBook
    {
        private ObservableList<Person> _people = new ObservableList<Person>();

        public IEnumerable<Person> People
        {
            get { return _people; }
        }

        public Person NewPerson()
        {
            Person item = new Person();
            _people.Add(item);
            return item;
        }

        public void DeletePerson(Person item)
        {
            _people.Remove(item);
        }

        public bool CanMoveDown(Person item)
        {
            return _people.IndexOf(item) < _people.Count - 1;
        }

        public bool CanMoveUp(Person item)
        {
            return _people.IndexOf(item) > 0;
        }

        public void MoveDown(Person item)
        {
            int index = _people.IndexOf(item);
            _people.RemoveAt(index);
            _people.Insert(index + 1, item);
        }

        public void MoveUp(Person item)
        {
            int index = _people.IndexOf(item);
            _people.RemoveAt(index);
            _people.Insert(index - 1, item);
        }
    }
}
