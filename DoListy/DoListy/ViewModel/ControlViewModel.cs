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
            //new Appointment
            //{
            //        Name = "AAAA",
            //        EventStart = DateTime.Now,
            //        EventEnd = DateTime.Now.AddHours(3),
            //        Colorbg = Colors.Blue,
            //        Reminders = new ObservableCollection<Reminder> { new Reminder
            //        {
            //            TimeBeforeStart = new TimeSpan(0,12,0)
            //        } }
            //},
            // new Appointment
            //{
            //        Name = "BBBB",
            //        EventStart = DateTime.Now.AddDays(1),
            //        EventEnd = DateTime.Now.AddDays(1).AddHours(3),
            //        Colorbg = Colors.Green,
            //        Reminders = new ObservableCollection<Reminder> { new Reminder
            //        {
            //            TimeBeforeStart = new TimeSpan(0,12,0)
            //        } }
            //}
        };


        public static List<Appointment> GetAppointments() => AppointmentsList;
        public static Appointment GetAppointmentByID(int AppointmentID)
        {
            var Appointmenttemp = AppointmentsList.FirstOrDefault(x => x.Id == AppointmentID);
            if (Appointmenttemp != null)
            {
                return Appointmenttemp;
            }
            return null;
        }

        public static void Update(int Id, Appointment appointment)
        {
            if (Id != appointment.Id) return;
            AppointmentsList.FirstOrDefault(x => x.Id ==  Id).Name = appointment.Name;
            AppointmentsList.FirstOrDefault(x => x.Id == Id).EventStart = appointment.EventStart;
            AppointmentsList.FirstOrDefault(x => x.Id == Id).EventEnd = appointment.EventEnd;
            if (appointment.Recurrencerule != null)
            {
                AppointmentsList.FirstOrDefault(x => x.Id == Id).Recurrencerule = appointment.Recurrencerule;
            }
        }

        public static void AddAppointment(ref Appointment temp)
        {
                //int maxID = AppointmentsList.Max(x => x.Id);
                //temp.Id = maxID + 1;
                AppointmentsList.Add(temp);
        }

    }
}
