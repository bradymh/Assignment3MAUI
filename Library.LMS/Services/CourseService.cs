using Library.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.LMS.Services
{
    public class CourseService
    {
        private List<Course> courses = new List<Course>();
        
        public CourseService() { }
        public CourseService(CourseService service)
        {
            this.courses = service.courses;
        }

        public void AddCourse(Course course) 
        { 
            courses.Add(course); 
        }

        public void RemoveCourse(Course course)
        {
            courses.Remove(course);
        }

        public void UpdateCourse(Course course,string prefix, string name, string description, int hours)
        {
            if(prefix != string.Empty)
            {
                course.CoursePrefix = prefix;
            }
            if(name != string.Empty)
            {
                course.Name = name;
            }
            if(description != string.Empty)
            {
                course.Description = description;
            }
            if(hours > 1)
            {
                course.CreditHours = hours;
            }
        }

        public void AddPerson(Course course, Person person)
        {
            course.Roster.Add(person);
            if(person is Student)
            {
                Student student = (Student)person;
                course.StudentGrades.Add(student, 0);
                student.AddGrade(course, 0);
            }
        }

        public void removePerson(Course course, Person person)
        {
            course.Roster.Remove(person);
            course.StudentGrades.Remove((Student)person);
            foreach(var a in course.Assignments)
            {
                a.RemoveGrade((Student)person);
            }
        }

        public void AddModule(Course course, Module module)
        {
            course.Modules.Add(module);
        }

        public void RemoveModule(Course course, Module module)
        {
            course.Modules.Remove(module);
        }

        public void AddAssignment(Course course, Assignment assignment)
        {
            course.Assignments.Add(assignment);
        }

        public void RemoveAssignment(Course course, Assignment assignment)
        {
            course.Assignments.Remove(assignment);
        }

        public void AddAnnouncment(Course course, string announcment)
        {
            course.Announcments.Add(announcment);
        }

        //using exact name
        public Course findCourse(string courseName)
        {
            foreach (Course a in courses)
            {
                if (a.Name == courseName) return a;
            }
            return null;
        }

        //courses that contain the info
        public List<Course> SearchForCourses(string info)
        {
            List<Course> courseList = new List<Course>();

            foreach(var c in courses)
            {
                if(c.Name.Contains(info) || c.Description.Contains(info))
                {
                    courseList.Add(c);
                }
            }
            return courseList;
        }

        public List<Course> getCourseList()
        {
            return courses;
        }

        
    }
}
