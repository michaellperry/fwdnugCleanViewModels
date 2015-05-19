using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TypicalViewModels.Models;

namespace TypicalViewModels.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Person> _people =
            new ObservableCollection<Person>();
        private Person _selectedPerson;

        public MainViewModel()
        {
            if (ViewModelBase.IsInDesignModeStatic)
                LoadDesignModeDocument();
            else
                LoadDocument();
            if (ViewModelBase.IsInDesignModeStatic)
                _selectedPerson = _people.First();
        }

        public IEnumerable<Person> People
        {
            get { return _people; }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }

            set
            {
                if (_selectedPerson == value)
                    return;

                _selectedPerson = value;
                RaisePropertyChanged(() => SelectedPerson);
            }
        }

        public ICommand AddItem
        {
            get
            {
                return new RelayCommand(delegate
                {
                    var person = new Person();
                    _people.Add(person);
                    SelectedPerson = person;
                });
            }
        }

        public ICommand DeleteItem
        {
            get
            {
                return new RelayCommand(delegate
                    {
                        _people.Remove(_selectedPerson);
                        SelectedPerson = null;
                    }, () => _selectedPerson != null );
            }
        }

        public ICommand MoveItemDown
        {
            get
            {
                return new RelayCommand(delegate
                    {
                        int index = _people.IndexOf(_selectedPerson);
                        _people.RemoveAt(index);
                        _people.Insert(index + 1, _selectedPerson);
                    }, () =>
                        _selectedPerson != null &&
                        _people.IndexOf(_selectedPerson) < _people.Count - 1
                    );
            }
        }

        public ICommand MoveItemUp
        {
            get
            {
                return new RelayCommand(delegate
                    {
                        int index = _people.IndexOf(_selectedPerson);
                        _people.RemoveAt(index);
                        _people.Insert(index - 1, _selectedPerson);
                    }, () =>
                        _selectedPerson != null &&
                        _people.IndexOf(_selectedPerson) > 0
                    );
            }
        }

        private void LoadDocument()
        {
            // TODO: Load your document here.
            var one = new Person();
            one.FirstName = "Charles";
            one.LastName = "Babbage";
            _people.Add(one);
            var two = new Person();
            two.FirstName = "Ada";
            two.LastName = "Lovelace";
            _people.Add(two);
            var three = new Person();
            three.FirstName = "Alan";
            three.LastName = "Turing";
            _people.Add(three);
        }

        private void LoadDesignModeDocument()
        {
            var one = new Person();
            one.FirstName = "Charles";
            one.LastName = "Babbage";
            _people.Add(one);
            var two = new Person();
            two.FirstName = "Ada";
            two.LastName = "Lovelace";
            _people.Add(two);
            var three = new Person();
            three.FirstName = "Alan";
            three.LastName = "Turing";
            _people.Add(three);
        }
    }
}
