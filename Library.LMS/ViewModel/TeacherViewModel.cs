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
    public class TeacherViewModel : INotifyPropertyChanged
    {
        public CourseService courseService { get; private set; }
        public PersonService personService { get; private set; }
        private Person user;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TeacherViewModel(Person user, CourseService Cservice, PersonService Pservice) 
        { 
            this.user = user;
            courseService = Cservice;
            personService = Pservice;
            PageTitle = "Signed in as " + user.Name;
        }

        string? _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle ?? string.Empty; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged(nameof(PageTitle));
            }
        }
    }
}
