using Library.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.LMS.Services
{
    public class PersonService
    {
        private List<Person> people = new List<Person>();

        public PersonService() { }
        public PersonService(PersonService service)
        {
            this.people = service.people;
        }

        public void AddPerson(Person person)
        {
            people.Add(person);
        }

        public void RemovePerson(Person person)
        {
            people.Remove(person);
        }

        public void UpdatePerson(Person person, string name, string classification)
        {
            if(name != string.Empty)
            {
                person.Name = name;
            }
            if(classification != string.Empty)
            {
                person.Classification = classification;
            }
        }

        public Person FindPerson(string name) 
        {
            foreach (Person person in people)
            {
                if(person.Name == name) return person;
            }
            return null;
        }

        public List<Person> SearchPeople(string name)
        {
            List<Person> list = new List<Person>();
            foreach (Person person in people)
            {
                if (person.Name.Contains(name))
                {
                    list.Add(person);
                }
            }
            return list;
        }

        public List<Person> ListStudents()
        {
            List<Person> list = new List<Person>();
            foreach (Person person in people)
            {
                if (person is Student)
                {
                    list.Add(person);
                }
            }
            return list;
        }

        public List<Person> ListTeachers()
        {
            List<Person> list = new List<Person>();
            foreach (Person person in people)
            {
                if (person is Instructor || person is TA)
                {
                    list.Add(person);
                }
            }
            return list;
        }

        public List<Person> GetPeople()
        {
            return people;
        }
    }
}
