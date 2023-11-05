using DoListy.ViewModel;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListy.ControlViewModel
{
    public class ControlViewModel
    {
        public ObservableCollection<SchedulerAppointment> SchedulerEvents { get; set; }

        public ObservableCollection<Appointment> AppointmentEvents {  get; set; }


        public List<Appointment> AppointmentsList = new List<Appointment>()
        {
            new Appointment
            {
                    Name = "AAAA",
                    EventStart = new DateTime(2023, 11 ,5,19,30, 30),
                    EventEnd = new DateTime(2023 , 11, 5, 22 , 30 ,30),
                    Color = Colors.Blue
            }
        };

        public ControlViewModel() 
        {
            this.AppointmentEvents = new ObservableCollection<Appointment>(AppointmentsList);
        }
        
    }
}
