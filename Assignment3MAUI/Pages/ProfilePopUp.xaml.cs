using CommunityToolkit.Maui.Views;
using Library.LMS.Models;

namespace Assignment3MAUI.Pages;

public partial class ProfilePopUp : Popup
{
    string Name = string.Empty, Classification = string.Empty;
    Person Profile;
    public ProfilePopUp(Person person)
    {
        InitializeComponent();
        Profile = person;
    }

    private void CancelBtn_Clicked(object sender, EventArgs e) => Close();

    private async void ChangeBtn_Clicked(object sender, EventArgs e)
    {
        if(Name != string.Empty) 
        {
            Profile.Name = Name;
        }
        if(Classification != string.Empty) 
        {
            Profile.Classification = Classification;
        }
        Close();
    }

    private void NameEntry_Completed(object sender, EventArgs e)
    {
        Name = ((Entry)sender).Text;
    }

    private void NameEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        Name = ((Entry)sender).Text;
    }

    private void ClassificationEntry_Completed(object sender, EventArgs e)
    {
        Classification = ((Entry)sender).Text;
    }

    private void ClassificationEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        Classification = ((Entry)sender).Text;
    }
}