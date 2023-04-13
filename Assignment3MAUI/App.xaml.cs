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
		Student me = new Student("Brady", "Junior");
		Instructor teach = new Instructor("What", "Instructor");
		personService.AddPerson(me);
		personService.AddPerson(teach);

		Course course = new Course("COP", "C#", "This is C#", 3);
		courseService.AddCourse(course);
		courseService.AddAnnouncment(course, new Announcment("Important Announcment", "This is an announcment"));
		courseService.AddPerson(course,me);
		courseService.AddPerson(course, teach);

		Assignment assignment = new Assignment("Assignment 1", "This is the first Assignment", "100", "4/12/2022");
		courseService.AddAssignment(course,assignment);

		List<ContentItem> contentItems = new List<ContentItem> { new PageItem("Page1", "This is a page", "Page.com"), new AssignmentItem(assignment) };
		Module module = new Module("Module 1", "The first Module");
		module.Content = contentItems;
		courseService.AddModule(course, module);

        MainPage = new NavigationPage(new MainPage(courseService, personService));
	}
}
