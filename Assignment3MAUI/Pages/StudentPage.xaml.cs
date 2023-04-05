using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.ViewModel;

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


	
}