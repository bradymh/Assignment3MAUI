using Library.LMS.Models;
using Library.LMS.Services;

namespace Assignment3MAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        CourseService courseService = new CourseService();
        PersonService personService = new PersonService();
		personService.AddPerson(new Student("brady", "Junior"));
		personService.AddPerson(new Instructor("what", "unoriginal"));

		courseService.AddCourse(new Course("COP", "C#", "This is C#", 3));


        MainPage = new NavigationPage(new MainPage(courseService, personService));
	}
}
