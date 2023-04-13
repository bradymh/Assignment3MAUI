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
    public class StudentViewModel : INotifyPropertyChanged
    {
        public CourseService courseService { get; private set; }
        public PersonService personService { get; private set; }
        public Student student { get; private set; }

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

        private ObservableCollection<Course> _announcments;
        public ObservableCollection<Course> Announcments
        {
            get { return _announcments; }
            private set
            {
                _announcments = value;
                OnPropertyChanged(nameof(Announcments));
            }
        }

        private ObservableCollection<Course> _roster;
        public ObservableCollection<Course> Roster
        {
            get { return _roster; }
            private set
            {
                _roster = value;
                OnPropertyChanged(nameof(Roster));
            }
        }

        private ObservableCollection<Course> _assignments;
        public ObservableCollection<Course> Assignments
        {
            get { return _assignments; }
            private set
            {
                _assignments = value;
                OnPropertyChanged(nameof(Assignments));
            }
        }

        private ObservableCollection<Course> _modules;
        public ObservableCollection<Course> Modules
        {
            get { return _modules; }
            private set
            {
                _modules = value;
                OnPropertyChanged(nameof(Modules));
            }
        }

        private string _homepage;
        public string HomePage
        {
            get { return _homepage; }
            private set
            {
                _homepage = value;
                OnPropertyChanged(nameof(HomePage));
            }
        }

        public void ListStuff()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public StudentViewModel(Student student, CourseService Cservice, PersonService Pservice) 
        {
            this.student = student;
            PageTitle = student.Name;
            courseService = Cservice;
            personService = Pservice;
            Courses = new ObservableCollection<Course>(courseService.GetCourseList());
        }

        string? _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle ?? string.Empty; }
            set
            {
                _pageTitle = "Signed in as: " + value;
                OnPropertyChanged(nameof(PageTitle));
            }
        }
          
        public string StudentInfoGet()
        {
            return $"ID: {student.Id}\nClassification: {student.Classification}\nGPA: {student.GPA}";
        }

        public List<Course> GetStudentCourses()
        {
            return courseService.PersonsCourses(student);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
