using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListy.ViewModel
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string Name { get; set; }
        public Brush Colorbg { get; set; }
        public string Recurrencerule { get; set; }
        public string Tag { get; set;}
    }
}
