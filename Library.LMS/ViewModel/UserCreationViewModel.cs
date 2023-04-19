using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.ViewModel
{
    public class UserCreationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public bool isStudent;
        private PersonService personService;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserCreationViewModel(bool isStudent, PersonService personService)
        {
            this.isStudent = isStudent;
            this.personService = personService;
        }

        public void CreateStudent(string Name,string Class)
        {
            Student student = new Student(Name,Class);
            personService.AddPerson(student);
            OnPropertyChanged(nameof(personService));
        }

        public void CreateInstructor(string Name, string Class)
        {
            Instructor instructor = new Instructor(Name,Class);
            personService.AddPerson(instructor);
            OnPropertyChanged(nameof(personService));
        }

        public void CreateTA(string Name, string Class)
        {
            TA ta = new TA(Name,Class);
            personService.AddPerson(ta);
            OnPropertyChanged(nameof(personService));
        }
    }
}
