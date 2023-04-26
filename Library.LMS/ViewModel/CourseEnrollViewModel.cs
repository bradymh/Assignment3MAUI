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
        public Person person { get; private set; }
        
        public bool EnrollOrUnenroll;
        private List<Course> PersonsCourses { get; set; }

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

        public CourseEnrollViewModel(CourseService courseService, PersonService personService, Person person, bool enroll)
        {
            CourseService = courseService;
            PersonService = personService;
            this.person = person;
            EnrollOrUnenroll = enroll;
            PersonsCourses = CourseService.GetPersonsCourses(person);
            Courses = new ObservableCollection<Course>(GetCourseList());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SearchCourses(string name)
        {
            if(EnrollOrUnenroll)
            {
                Courses = new(CourseService.SearchForCourses(name));
            }
            else
            {
                List<Course> courses = new();
                foreach (var c in PersonsCourses)
                {
                    if (c.Name.Contains(name) || c.Code.Contains(name))
                    {
                        courses.Add(c);
                    }
                }
                Courses = new(courses);
            }
        }

        public List<Course> GetCourseList()
        {
            if (EnrollOrUnenroll)
            {
                return CourseService.GetCourseList();
            }
            return CourseService.GetPersonsCourses(person);
        }

        public void EnrollInCourse(Course course)
        {
            CourseService.AddPerson(course, person);
        }

        public void UnenrollInCourse(Course course)
        {
            CourseService.RemovePerson(course, person);
        }
    }
}
