using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanViewModels.Models;
using Assisticant;

namespace CleanViewModels.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        private AddressBook _addressBook;
		private Selection _selection;

        public ViewModelLocator()
        {
			if (DesignMode)
				_addressBook = LoadDesignModeDocument();
			else
				_addressBook = LoadDocument();
			_selection = new Selection();
            if (DesignMode)
                _selection.SelectedPerson = _addressBook.People.First();
        }

        public object Main
        {
            get { return ViewModel(() => new MainViewModel(_addressBook, _selection)); }
        }

		public object PersonDetail
		{
			get
			{
				return ViewModel(() => _selection.SelectedPerson == null
					? null
					: new PersonViewModel(_selection.SelectedPerson));
			}
		}

		private AddressBook LoadDocument()
		{
			// TODO: Load your document here.
            AddressBook document = new AddressBook();
            var one = document.NewPerson();
            one.FirstName = "Charles";
            one.LastName = "Babbage";
            var two = document.NewPerson();
            two.FirstName = "Ada";
            two.LastName = "Lovelace";
            var three = document.NewPerson();
            three.FirstName = "Alan";
            three.LastName = "Turing";
            return document;
		}

		private AddressBook LoadDesignModeDocument()
		{
            AddressBook document = new AddressBook();
            var one = document.NewPerson();
            one.FirstName = "Charles";
            one.LastName = "Babbage";
            var two = document.NewPerson();
            two.FirstName = "Ada";
            two.LastName = "Lovelace";
            var three = document.NewPerson();
            three.FirstName = "Alan";
            three.LastName = "Turing";
            return document;
		}
    }
}
