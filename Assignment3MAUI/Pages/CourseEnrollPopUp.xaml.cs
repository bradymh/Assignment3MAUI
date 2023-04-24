using CommunityToolkit.Maui.Views;
using Library.LMS.Models;
using System.Collections.ObjectModel;

namespace Assignment3MAUI.Pages;

public partial class CourseEnrollPopUp : Popup
{
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

    public CourseEnrollPopUp(List<Course> courses)
	{
		InitializeComponent();
        Courses = new ObservableCollection<Course>(courses);
        this.BindingContext = this;
	}

	private void Button_Clicked(object sender, EventArgs e) => Close();

    private void CourseSearchEntry_Completed(object sender, EventArgs e)
    {

    }

    private void CourseSearchEntry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}