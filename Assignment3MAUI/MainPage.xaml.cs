using Library.LMS.Models;

namespace Assignment3MAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void StudentLogin(object sender, EventArgs e)
    {
		Navigation.PushAsync(new StudentPage());
    }

	private async void TeacherLogin(object sender, EventArgs e)
	{
		await DisplayAlert("Alert", Title, "OK");
	}
}

