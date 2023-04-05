using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.ViewModel
{
    public class UserSelectViewModel : INotifyPropertyChanged
    {
        public CourseService courseService { get; private set; }
        public PersonService personService { get; private set; }

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            private set
            {
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool StudentOrteacher; //true if student, false if teacher
        public UserSelectViewModel(bool studentorteacher, CourseService Cservice, PersonService Pservice) 
        {
            StudentOrteacher = studentorteacher;
            personService = Pservice;
            courseService = Cservice;
            if (StudentOrteacher)
            {
                PageTitle = "Select a Student";
                People = new ObservableCollection<Person>(GetStudents());
                OnPropertyChanged(nameof(People));
            }
            else
            {
                PageTitle = "Select a Teacher";
                People = new ObservableCollection<Person>(GetTeachers());
                OnPropertyChanged(nameof(People));
            }
        }


        string? _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            private set
            {
                _pageTitle = value;
                OnPropertyChanged(nameof(PageTitle));
            }
        }

        private List<Person> GetStudents()
        {
            return personService.ListStudents();
        }

        private List<Person> GetTeachers()
        {
            return personService.ListTeachers();
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
