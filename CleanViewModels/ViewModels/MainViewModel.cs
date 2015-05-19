using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CleanViewModels.Models;
using Assisticant;

namespace CleanViewModels.ViewModels
{
    public class MainViewModel
    {
        private readonly AddressBook _document;
		private readonly Selection _selection;

        public MainViewModel(AddressBook document, Selection selection)
        {
            _document = document;
			_selection = selection;
        }

        public IEnumerable<PersonHeader> People
        {
            get
            {
                return
                    from item in _document.People
                    select new PersonHeader(item);
            }
        }

        public PersonHeader SelectedPerson
        {
            get
            {
                return _selection.SelectedPerson == null
                    ? null
                    : new PersonHeader(_selection.SelectedPerson);
            }
            set
            {
                if (value != null)
                    _selection.SelectedPerson = value.Person;
                else
                    _selection.SelectedPerson = null;
            }
        }

        public PersonViewModel ItemDetail
        {
            get
            {
                return _selection.SelectedPerson == null
                    ? null
                    : new PersonViewModel(_selection.SelectedPerson);
            }
        }

        public ICommand AddItem
        {
            get
            {
                return MakeCommand
                    .Do(delegate
                    {
                        _selection.SelectedPerson = _document.NewPerson();
                    });
            }
        }

        public ICommand DeleteItem
        {
            get
            {
                return MakeCommand
                    .When(() => _selection.SelectedPerson != null)
                    .Do(delegate
                    {
                        _document.DeletePerson(_selection.SelectedPerson);
                        _selection.SelectedPerson = null;
                    });
            }
        }

        public ICommand MoveItemDown
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _selection.SelectedPerson != null &&
                        _document.CanMoveDown(_selection.SelectedPerson))
                    .Do(delegate
                    {
                        _document.MoveDown(_selection.SelectedPerson);
                    });
            }
        }

        public ICommand MoveItemUp
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _selection.SelectedPerson != null &&
                        _document.CanMoveUp(_selection.SelectedPerson))
                    .Do(delegate
                    {
                        _document.MoveUp(_selection.SelectedPerson);
                    });
            }
        }
    }
}
