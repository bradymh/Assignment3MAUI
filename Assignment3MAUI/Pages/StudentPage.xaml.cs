using Assignment3MAUI.Pages;
using CommunityToolkit.Maui.Views;
using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.ViewModel;
using Microsoft.Maui.Controls;

using System.Xml.Linq;
using System;

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

	private async void SignOut(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
	}

    private async void ShowProfile(object sender, EventArgs e)
    {
		await DisplayAlert(viewModel.student.Name, viewModel.StudentInfoGet(),"OK");
    }
	
	private async void EditProfile(object sender, EventArgs e)
	{
		var popup = new ProfilePopUp(viewModel.student);
        var result = await this.ShowPopupAsync(popup);

		if(result is bool boolResult)
		{
			if (boolResult)
			{
				Refresh();
			}
		}
	}

	private void Refresh()
	{
		this.BindingContext = new StudentViewModel(viewModel.student, viewModel.courseService, viewModel.personService);
	}

    private void RefreshButton(object sender, EventArgs e)
    {
		Refresh();
	}
}