using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Announcment
    {
        private string? _title;
        public string Title { get { return _title ?? string.Empty; } set { _title = value; } }

        private string? _description;
        public string Description { get { return _description ?? string.Empty; } set { _description = value; } }

        public Announcment() { }
        public Announcment(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
