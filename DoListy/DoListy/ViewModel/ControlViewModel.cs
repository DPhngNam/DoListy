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
                    EventStart = new DateTime(2023, 11 ,14,10,30, 00),
                    EventEnd = new DateTime(2023 , 11, 14, 10, 50 ,00),
                    Colorbg = Colors.Blue,
                    Reminders = new ObservableCollection<Reminder> { new Reminder
                    {
                        TimeBeforeStart = new TimeSpan(0,3,0)
                    } }
            }
        };
        public static List<Appointment> GetAppointments() => AppointmentsList;

        public static void AddAppointment(Appointment temp)
        {
            AppointmentsList.Add(temp);
        }
        
    }
}
