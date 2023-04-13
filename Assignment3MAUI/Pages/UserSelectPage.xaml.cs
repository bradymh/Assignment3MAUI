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
		if (args.SelectedItem is Student student) 
		{
			user = student;
		}
		else if(args.SelectedItem is Instructor instructor)
		{
			user = instructor;
		}
		else
		{
			user = (TA)args.SelectedItem;
		}
	}

	public void Login(object sender, EventArgs e)
	{
		if(user == null)
		{
			return;
		}
		if(user is Student)
		{
			Navigation.PushAsync(new StudentPage(user as Student, viewModel.courseService, viewModel.personService));
		}
		else
		{
			Navigation.PushAsync(new TeacherPage(user, viewModel.courseService, viewModel.personService));
		}
	}

	public async void CreateNewUser(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new UserCreationPage(viewModel.StudentOrteacher, viewModel.personService));
		OnPropertyChanged(nameof(viewModel.People));
	}

}