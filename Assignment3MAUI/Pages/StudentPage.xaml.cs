using Assignment3MAUI.Pages;
using CommunityToolkit.Maui.Views;
using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.ViewModel;
using Microsoft.Maui.Controls;
using System.Xml.Linq;
using System;
using System.Collections.ObjectModel;

namespace Assignment3MAUI;

public partial class StudentPage : ContentPage
{
	private StudentViewModel ViewModel;
	public StudentPage(Student student, CourseService Cservice, PersonService Pservice)
	{
		InitializeComponent();
		ViewModel = new StudentViewModel(student,Cservice,Pservice);
		BindingContext = ViewModel;
	}

	private async void SignOut(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
	}

    private async void ShowProfile(object sender, EventArgs e)
    {
		await DisplayAlert(ViewModel.student.Name, ViewModel.StudentInfoGet(),"OK");
    }
	
	private async void EditProfile(object sender, EventArgs e)
	{
		var popup = new ProfilePopUp(ViewModel.student);
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
        ViewModel = new StudentViewModel(ViewModel);
        this.BindingContext = ViewModel;
	}

    private void RefreshButton(object sender, EventArgs e)
    {
		Refresh();
	}

    private void CourseList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        ViewModel.SelectCourse(e.Item as Course);
    }


    private void HomeBtn_Clicked(object sender, EventArgs e)
    {
        HomePageLabel.IsVisible = true;
        AssignmentsList.IsVisible = false;
        AnnouncmentsList.IsVisible = false;
        ModulesList.IsVisible = false;
        RosterList.IsVisible = false;
    }

    private void AssignmentsBtn_Clicked(object sender, EventArgs e)
    {
        AssignmentsList.IsVisible = true;
        HomePageLabel.IsVisible = false;
        AnnouncmentsList.IsVisible = false;
        ModulesList.IsVisible = false;
        RosterList.IsVisible = false;
    }

    private async void AssignmentsList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Assignment assignment = (Assignment)e.Item;
        await DisplayAlert(assignment.Name, $"{assignment.DueDate}\n{assignment.TotalAvailablePoints}\n{assignment.Description}", "OK");
    }

    private void AnnouncmentsBtn_Clicked(object sender, EventArgs e)
    {
        HomePageLabel.IsVisible = false;
        AssignmentsList.IsVisible = false;
        AnnouncmentsList.IsVisible = true;
        ModulesList.IsVisible = false;
        RosterList.IsVisible = false;
    }

    private async void AnnouncmentsList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Announcment announcment = (Announcment)e.Item;
        await DisplayAlert(announcment.Title, announcment.Description, "OK");
    }

    private void ModulesBtn_Clicked(object sender, EventArgs e)
    {
        HomePageLabel.IsVisible = false;
        AssignmentsList.IsVisible = false;
        AnnouncmentsList.IsVisible = false;
        ModulesList.IsVisible = true;
        RosterList.IsVisible = false;
    }

    private void ModulesList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Module module = (Module)e.Item;
        var popup = new ModulePopUp(module);
        this.ShowPopup(popup);
    }

    private void PeopleBtn_Clicked(object sender, EventArgs e)
    {
        HomePageLabel.IsVisible = false;
        AssignmentsList.IsVisible = false;
        AnnouncmentsList.IsVisible = false;
        ModulesList.IsVisible = false;
        RosterList.IsVisible = true;
    }

    private void CurrentCourseBtn_Clicked(object sender, EventArgs e)
    {
        ViewModel.SetCurrentCourses();
        Refresh();
    }

    private void PreviousCourseBtn_Clicked(object sender, EventArgs e)
    {
        ViewModel.SetPreviousCourses();
        Refresh();
    }

    private void EnrollBtn_Clicked(object sender, EventArgs e)
    {

    }

    private void UnenrollBtn_Clicked(object sender, EventArgs e)
    {

    }

}