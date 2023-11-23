using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DoListy.ViewModel
{
    [Table ("Appointment")]
    public class Appointment
    {
        public static int count = 0;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        [Unique]
        public string Name { get; set; }
        public Brush Colorbg { get; set; }
        public string Recurrencerule { get; set; }
        public string Note { get; set;}
        public string State { get; set; }
        public ObservableCollection<Reminder> Reminders { get; set; }
    }
}
