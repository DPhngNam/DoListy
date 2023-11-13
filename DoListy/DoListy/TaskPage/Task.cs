using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListy.TaskManager
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string Title { get; set; }
        public string Remind { get; set; }
        public string Repeat { get; set; }
        public string Recurrencerule { get; set; }
        public string Tag { get; set; }
        public string State { get; set; }
    }
}
