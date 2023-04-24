using CommunityToolkit.Maui.Views;
using Library.LMS.Models;

namespace Assignment3MAUI.Pages;

public partial class ModulePopUp : Popup
{
	Module module;
	public ModulePopUp(Module module)
	{
		InitializeComponent();
		this.module = module;
		BindingContext = module;
	}

    private void ExitBtn_Clicked(object sender, EventArgs e) => Close();

    private void ContentItemList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		
		//is it bad to have this many popups in a row
		//Who knows!!!
    }
}