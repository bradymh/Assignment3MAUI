using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.ViewModel;

namespace Assignment3MAUI.Pages;

public partial class UserSelectPage : ContentPage
{
	private UserSelectViewModel viewModel;
	private Person user;

	public UserSelectPage(bool isStudent, CourseService courseService, PersonService personService)
	{
		viewModel = new UserSelectViewModel(isStudent, courseService, personService);
		InitializeComponent();
        this.BindingContext = viewModel;
    }

	public void SelectUser(object sender, SelectedItemChangedEventArgs args)
	{
		if (args.SelectedItem is Student) 
		{
			user = (Student)args.SelectedItem;
		}
		else if(args.SelectedItem is Instructor)
		{
			user = (Instructor)args.SelectedItem;
		}
		else
		{
			user = (TA)args.SelectedItem;
		}
	}

	public void Login(object sender, EventArgs e)
	{
		if(user is Student)
		{
			Navigation.PushAsync(new StudentPage(user as Student));
		}
		//else if (user is Instructor)
		//{
		//	Navigation.PushAsync();
		//}
	}

	public async void CreateNewUser(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new UserCreationPage(viewModel.StudentOrteacher, viewModel.personService));
		OnPropertyChanged(nameof(viewModel.People));
	}

}