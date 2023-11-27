using DoListy.ViewModel;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using DoListy.Database;

namespace DoListy.ControlViewModel
{
    public class ControlViewModel
    {
<<<<<<< Updated upstream

        public static  List<Appointment> AppointmentsList = new List<Appointment> ();



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
    


        public static  List<Appointment> GetAppointments()
=======
        string _dbpath;
        private SQLiteAsyncConnection conn;
        public ControlViewModel(string dbpath)
        {
            _dbpath = dbpath;
        }
        private async Task Init()
>>>>>>> Stashed changes
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(_dbpath);
            await conn.CreateTableAsync<Appointment>();
        }
        public async Task<List<Appointment>> GetAppointments()
        {
            await Init();
            return await conn.Table<Appointment>().ToListAsync();
        }
        public async Task AddAppointment(Appointment app)
        {
            await Init();
            int result = 0;
            await Init();
            result = await conn.InsertAsync(new Appointment());
        }
        public async Task DeleteAppointment(int id)
        {
            await Init();
            await conn.DeleteAsync(new { ID = id });
        }
        public async Task<Appointment> GetAppointmentByID(int AppointmentID)
        {
            await Init();
            var temp = from u in conn.Table<Appointment>()
                       where u.Id == AppointmentID
                       select u;
            return await temp.FirstOrDefaultAsync();
        }

        public async Task Update(Appointment appointment)
        {
            await Init();
            int result = 0;
            result = await conn.UpdateAsync(appointment);
        }
    }

}
