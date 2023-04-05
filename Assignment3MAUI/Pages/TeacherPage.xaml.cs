using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.ViewModel;

namespace Assignment3MAUI.Pages;

public partial class TeacherPage : ContentPage
{
	private TeacherViewModel viewModel;

	public TeacherPage(Person person, CourseService Cservice, PersonService Pservice)
	{
		InitializeComponent();
		viewModel = new TeacherViewModel(person, Cservice, Pservice);
		BindingContext = viewModel;
	}
}