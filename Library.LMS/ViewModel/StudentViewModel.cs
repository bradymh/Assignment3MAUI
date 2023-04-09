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
    public class StudentViewModel : INotifyPropertyChanged
    {
        public CourseService courseService { get; private set; }
        public PersonService personService { get; private set; }
        public Student student { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public StudentViewModel(Student student, CourseService Cservice, PersonService Pservice) 
        {
            this.student = student;
            PageTitle = student.Name;
            courseService = Cservice;
            personService = Pservice;
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

        private string _studentinfo;
        public string StudentInfo { get { return _studentinfo; } set
            {
                _studentinfo = $"ID: {student.Id}\nGPA: {student.GPA}";
                OnPropertyChanged(nameof(StudentInfo));
            }
        }

        public string StudentInfoGet()
        {
            return $"ID: {student.Id}\nClassification: {student.Classification}\nGPA: {student.GPA}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
