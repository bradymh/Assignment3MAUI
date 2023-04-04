using Assignment3MAUI.Pages;
using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.ViewModel;
using System.Runtime.CompilerServices;

namespace Assignment3MAUI;

public partial class MainPage : ContentPage
{
	private MainViewModel viewModel;
	
	public MainPage(CourseService Cservice, PersonService Pservice)
	{
		viewModel = new MainViewModel(Cservice, Pservice);
		this.BindingContext = viewModel;
		InitializeComponent();
	}

    private void StudentLogin(object sender, EventArgs e)
    {
		Navigation.PushAsync(new UserSelectPage(true, viewModel.courseService, viewModel.personService));
    }

	private void TeacherLogin(object sender, EventArgs e)
	{
		Navigation.PushAsync(new UserSelectPage(false, viewModel.courseService, viewModel.personService));
	}
}

