using Library.LMS.Services;
using Library.LMS.ViewModel;

namespace Assignment3MAUI.Pages;

public partial class UserCreationPage : ContentPage
{
	private string Name, Class;
	private UserCreationViewModel viewModel;
	public UserCreationPage(bool isStudent, PersonService personService)
	{
		InitializeComponent();
		viewModel = new UserCreationViewModel(isStudent, personService);
	}

	public void SetName(object sender, EventArgs e)
	{
		Name = ((Entry)sender).Text;
	}

	public void SetClass(object sender, EventArgs e)
	{

		Class = ((Entry)sender).Text;
    }

	public async void CancelCreation(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}

    private void NameEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
		Name = ((Entry)sender).Text;
    }

    private void ClassificationEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
		Class = ((Entry)sender).Text;
    }

    public async void CreateNewUser(object sender, EventArgs e)
	{
		if(Name == null || Class == null) 
		{
			await DisplayAlert("Alert", "Missing name or classification", "OK");
			return;
		}
		if(viewModel.isStudent)
		{
			viewModel.CreateStudent(Name,Class);
		}
		else
		{
            string action = await DisplayActionSheet("User is?", "Cancel", null, "Instructor", "TA");
			if(action == "Instructor")
			{
				viewModel.CreateInstructor(Name,Class);
			}
			else if(action == "TA")
			{
				viewModel.CreateTA(Name,Class);
			}
        }
		await Navigation.PopModalAsync();
	}
}