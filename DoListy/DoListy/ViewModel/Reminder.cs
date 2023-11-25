using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListy.ViewModel
{
    public class Reminder
    {
        public Reminder() 
        {
            IsDismissed = false;
        }
        public bool IsDismissed { get; set; }
        public TimeSpan TimeBeforeStart { get; set; }
    }
}
