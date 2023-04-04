using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.ViewModel;

namespace Assignment3MAUI.Pages;

public partial class UserSelectPage : ContentPage
{
	private UserSelectViewModel viewModel;

	public UserSelectPage(bool isStudent, CourseService courseService, PersonService personService)
	{
		viewModel = new UserSelectViewModel(isStudent, courseService, personService);
		InitializeComponent();
        this.BindingContext = viewModel;
    }



}