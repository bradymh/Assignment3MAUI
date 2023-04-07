using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.ViewModel;
using Microsoft.Maui.Controls;

namespace Assignment3MAUI;

public partial class StudentPage : ContentPage
{
	private StudentViewModel viewModel;

	public StudentPage(Student student, CourseService Cservice, PersonService Pservice)
	{
		InitializeComponent();
		viewModel = new StudentViewModel(student,Cservice,Pservice);
		BindingContext = viewModel;
	}

	public async void SignOut(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
	}

    private async void ShowProfile(object sender, EventArgs e)
    {
		await DisplayAlert(viewModel.student.Name, viewModel.StudentInfoGet(),"OK");
    }
	
	private async void EditProfile(object sender, EventArgs e)
	{
		
	}
}