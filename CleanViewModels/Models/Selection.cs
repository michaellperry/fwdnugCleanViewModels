using System.Linq;
using Assisticant.Fields;

namespace CleanViewModels.Models
{
    public class Selection
    {
        private Observable<Person> _selectedItem = new Observable<Person>();

        public Person SelectedPerson
        {
            get { return _selectedItem; }
            set { _selectedItem.Value = value; }
        }
    }
}
