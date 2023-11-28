using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DoListy.ViewModel
{
    [Table("Appointment")]
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string Name { get; set; }
        public string Colorbg {  get; set; }

        public string Recurrencerule { get; set; }
        public string Note { get; set;}
        public string State { get; set; }
    }
    
}
