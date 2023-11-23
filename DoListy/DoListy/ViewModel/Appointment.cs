using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DoListy.ViewModel
{
<<<<<<< HEAD

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
=======
    [Table ("Appointment")]
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
>>>>>>> 8c8a0ac95b961cb6629884c1eac8d83c116bedb5
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
