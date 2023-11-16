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
                    EventStart = new DateTime(2023, 11 ,16,20,50, 00),
                    EventEnd = new DateTime(2023 , 11, 16, 22, 30 ,00),
                    Colorbg = Colors.Blue,
                    Reminders = new ObservableCollection<Reminder> { new Reminder
                    {
                        TimeBeforeStart = new TimeSpan(0,12,0)
                    } }
            }
        };
        public static List<Appointment> GetAppointments() => AppointmentsList;
        public static Appointment GetAppointmentByID(int AppointmentID)
        {
            var Appointmenttemp = AppointmentsList.FirstOrDefault(x => x.Id == AppointmentID);
            if (Appointmenttemp != null)
            {
                return new Appointment
                {
                    Id = Appointmenttemp.Id,
                    Name = Appointmenttemp.Name,
                    EventStart = Appointmenttemp.EventStart,
                    EventEnd = Appointmenttemp.EventEnd,
                    Colorbg = Appointmenttemp.Colorbg,
                    Recurrencerule = Appointmenttemp.Recurrencerule,
                    Reminders = Appointmenttemp.Reminders,
                };
            }
            return null;
        }

        public static void AddAppointment(Appointment temp)
        {
            int maxID = AppointmentsList.Max(x => x.Id);
            temp.Id = maxID + 1;
            AppointmentsList.Add(temp);
        }

    }
}
