using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //public ObservableCollection<SupportTicket> SupportTickets { get; set; }

        //private SupportTicket selectedTicket;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            //SupportTickets = new ObservableCollection<SupportTicket>();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
