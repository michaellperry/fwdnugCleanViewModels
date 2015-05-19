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

        private RelayCommand _addItemCommand;
        private RelayCommand _deleteItemCommand;
        private RelayCommand _moveItemDownCommand;
        private RelayCommand _moveItemUpCommand;
        public MainViewModel()
        {
            if (ViewModelBase.IsInDesignModeStatic)
                LoadDesignModeDocument();
            else
                LoadDocument();
            if (ViewModelBase.IsInDesignModeStatic)
                _selectedPerson = _people.First();

            _addItemCommand = new RelayCommand(delegate
            {
                var person = new Person();
                _people.Add(person);
                SelectedPerson = person;
            });

            _deleteItemCommand = new RelayCommand(delegate
            {
                _people.Remove(_selectedPerson);
                SelectedPerson = null;
            }, () =>
                _selectedPerson != null
            );

            _moveItemDownCommand = new RelayCommand(delegate
            {
                var person = _selectedPerson;
                int index = _people.IndexOf(person);
                _people.RemoveAt(index);
                _people.Insert(index + 1, person);
                 SelectedPerson = person;
            }, () =>
                _selectedPerson != null &&
                _people.IndexOf(_selectedPerson) < _people.Count - 1
            );

            _moveItemUpCommand = new RelayCommand(delegate
            {
                var person = _selectedPerson;
                int index = _people.IndexOf(person);
                _people.RemoveAt(index);
                _people.Insert(index - 1, person);
                 SelectedPerson = person;
           }, () =>
                _selectedPerson != null &&
                _people.IndexOf(_selectedPerson) > 0
            );
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

                _deleteItemCommand.RaiseCanExecuteChanged();
                _moveItemUpCommand.RaiseCanExecuteChanged();
                _moveItemDownCommand.RaiseCanExecuteChanged();
            }
        }

        public ICommand AddItem
        {
            get { return _addItemCommand; }
        }

        public ICommand DeleteItem
        {
            get { return _deleteItemCommand; }
        }

        public ICommand MoveItemDown
        {
            get { return _moveItemDownCommand; }
        }

        public ICommand MoveItemUp
        {
            get { return _moveItemUpCommand; }
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
