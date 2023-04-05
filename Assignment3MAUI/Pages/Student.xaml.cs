using Library.LMS.Models;
using Library.LMS.ViewModel;

namespace Assignment3MAUI;

public partial class StudentPage : ContentPage
{
	private StudentViewModel viewModel;

	public StudentPage(Student student)
	{
		InitializeComponent();
		viewModel = new StudentViewModel(student);
		BindingContext = viewModel;
	}


	
}