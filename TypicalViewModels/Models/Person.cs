using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace TypicalViewModels.Models
{
    public class Person : ObservableObject
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                if (_firstName == value)
                {
                    return;
                }

                _firstName = value;
                RaisePropertyChanged(() => FirstName);
                RaisePropertyChanged(() => Name);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                if (_lastName == value)
                {
                    return;
                }

                _lastName = value;
                RaisePropertyChanged(() => LastName);
                RaisePropertyChanged(() => Name);
            }
        }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName) &&
                    string.IsNullOrEmpty(LastName))
                    return "<new person>";

                return String.Format("{0} {1}",
                    FirstName,
                    LastName);
            }
        }
    }
}
