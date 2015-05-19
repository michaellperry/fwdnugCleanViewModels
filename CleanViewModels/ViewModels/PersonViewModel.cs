using System;
using System.Collections.Generic;
using System.Linq;
using CleanViewModels.Models;

namespace CleanViewModels.ViewModels
{
    public class PersonViewModel
    {
        private readonly Person _person;

        public PersonViewModel(Person person)
        {
            _person = person;
        }

        public string FirstName
        {
            get { return _person.FirstName; }
            set { _person.FirstName = value; }
        }

        public string LastName
        {
            get { return _person.LastName; }
            set { _person.LastName = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            PersonViewModel that = obj as PersonViewModel;
            if (that == null)
                return false;
            return Object.Equals(this._person, that._person);
        }

        public override int GetHashCode()
        {
            return _person.GetHashCode();
        }
    }
}
