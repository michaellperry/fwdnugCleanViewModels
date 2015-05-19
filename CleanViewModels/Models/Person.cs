using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assisticant.Fields;

namespace CleanViewModels.Models
{
    public class Person
    {
        private Observable<string> _firstName =
            new Observable<string>();
        private Observable<string> _lastName =
            new Observable<string>();

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName.Value = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName.Value = value; }
        }
    }
}
