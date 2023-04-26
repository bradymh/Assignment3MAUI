using CommunityToolkit.Maui.Views;
using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.ViewModel;
using System.Collections.ObjectModel;

namespace Assignment3MAUI.Pages;

public partial class CourseEnrollPopUp : Popup
{
    private CourseEnrollViewModel viewModel;
    public CourseEnrollPopUp(PersonService personService, CourseService courseService, Person person, bool enroll)
	{
		InitializeComponent();
        viewModel = new CourseEnrollViewModel(courseService,personService,person, enroll);
        this.BindingContext = viewModel;
	}

	private void Button_Clicked(object sender, EventArgs e) => Close();

    private void CourseSearchEntry_Completed(object sender, EventArgs e)
    {
        string name = ((Entry)sender).Text;
        viewModel.SearchCourses(name);
    }

    private void CourseSearchEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string name = ((Entry)sender).Text;
        viewModel.SearchCourses(name);
    }

    private async void CourseList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Course TappedCourse = (Course)e.Item;
        if (viewModel.EnrollOrUnenroll)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert(TappedCourse.Name, TappedCourse.Description, "Enroll", "Cancel");
            if(answer)
            {
                viewModel.EnrollInCourse(TappedCourse);
            }
        }
        else
        {
            bool answer = await Application.Current.MainPage.DisplayAlert(TappedCourse.Name, TappedCourse.Description, "Unenroll", "Cancel");
            if (answer)
            {
                viewModel.UnenrollInCourse(TappedCourse);
            }
        }
    }
}