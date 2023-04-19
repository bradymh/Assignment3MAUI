using Library.LMS.Models;
using Library.LMS.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

        private ObservableCollection<Announcment> _announcments;
        public ObservableCollection<Announcment> Announcments
        {
            get { return _announcments; }
            private set
            {
                _announcments = value;
                OnPropertyChanged(nameof(Announcments));
            }
        }

        private ObservableCollection<Person> _roster;
        public ObservableCollection<Person> Roster
        {
            get { return _roster; }
            private set
            {
                _roster = value;
                OnPropertyChanged(nameof(Roster));
            }
        }

        private ObservableCollection<Assignment> _assignments;
        public ObservableCollection<Assignment> Assignments
        {
            get { return _assignments; }
            private set
            {
                _assignments = value;
                OnPropertyChanged(nameof(Assignments));
            }
        }

        private ObservableCollection<Module> _modules;
        public ObservableCollection<Module> Modules
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public StudentViewModel(Student student, CourseService Cservice, PersonService Pservice)
        {
            this.student = student;
            courseService = Cservice;
            personService = Pservice;

            PageTitle = student.Name;

            Courses = new ObservableCollection<Course>(courseService.GetCurrentPersonsCourses(student));
        }

        public StudentViewModel(StudentViewModel viewModel)
        {
            this.student = viewModel.student;
            courseService = viewModel.courseService;
            personService = viewModel.personService;
            PageTitle = student.Name;
            Courses = viewModel.Courses;
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

        public List<Course> GetCurrentStudentCourses()
        {
            return courseService.GetCurrentPersonsCourses(student);
        }

        public List<Course> GetStudentCourses()
        {
            return courseService.GetPersonsCourses(student);
        }

        public void SelectCourse(Course SelectedCourse)
        {
            Announcments = new ObservableCollection<Announcment>(SelectedCourse.Announcments);
            Roster = new ObservableCollection<Person>(SelectedCourse.Roster);
            Assignments = new ObservableCollection<Assignment>(SelectedCourse.Assignments);
            Modules = new ObservableCollection<Module>(SelectedCourse.Modules);
            HomePage = $"{SelectedCourse.Name}\n{SelectedCourse.Description}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
