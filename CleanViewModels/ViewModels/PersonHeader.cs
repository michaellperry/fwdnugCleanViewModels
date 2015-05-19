using System;
using System.Linq;
using CleanViewModels.Models;

namespace CleanViewModels.ViewModels
{
    public class PersonHeader
    {
        private readonly Person _person;

        public PersonHeader(Person person)
        {
            _person = person;
        }

        public Person Person
        {
            get { return _person; }
        }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_person.FirstName) &&
                    string.IsNullOrEmpty(_person.LastName))
                    return "<new person>";

                return String.Format("{0} {1}",
                    _person.FirstName,
                    _person.LastName);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            PersonHeader that = obj as PersonHeader;
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
