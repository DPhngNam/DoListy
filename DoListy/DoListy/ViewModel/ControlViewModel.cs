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

        public static List<Appointment> AppointmentsList = new List<Appointment>()
        {
            new Appointment
            {
                    Name = "AAAA",
                    EventStart = new DateTime(2023, 11 ,5,19,30, 30),
                    EventEnd = new DateTime(2023 , 11, 5, 22 , 30 ,30),
                    Colorbg = Colors.Blue,
            }
        };
        public static List<Appointment> GetAppointments() => AppointmentsList;

        public static void AddAppointment(Appointment temp)
        {
            AppointmentsList.Add(temp);
        }
        
    }
}
