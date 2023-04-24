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
    public class CourseEnrollViewModel : INotifyPropertyChanged
    {
        public CourseService CourseService { get; private set; }
        public PersonService PersonService { get; private set; }
        public Person Person { get; private set; }

        private ObservableCollection<Course> _courses;
        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            private set
            {
                _courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        public CourseEnrollViewModel(CourseService courseService, PersonService personService, Person person)
        {
            CourseService = courseService;
            PersonService = personService;
            Person = person;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
