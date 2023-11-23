using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListy.ViewModel
{

    public class Appointment
    {
        public Appointment() 
        {
            Id = count++;
        }
        public Appointment(int temp)
        {

        }
        public static int count = 0;
        public int  Id { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string Name { get; set; }
        public Brush Colorbg { get; set; }
        public string Recurrencerule { get; set; }
        public string Note { get; set;}
        public string State { get; set; }
        public ObservableCollection<Reminder> Reminders { get; set; }
    }
    
}
