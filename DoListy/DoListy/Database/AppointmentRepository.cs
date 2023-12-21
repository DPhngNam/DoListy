using DoListy.ViewModel;
using SQLite;

namespace DoListy.Database
{
   public class AppointmentRepository
    {
        string _dbpath;
        static SQLiteConnection conn;
        public AppointmentRepository(string dbpath)
        {
            _dbpath = dbpath;
        }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbpath);
            conn.CreateTable<Appointment>();
            conn.CreateTable<Goal>();
            conn.CreateTable<Settings>();
            conn.CreateTable<Reminder>();
        }
        public List<Appointment> GetAppointments()
        {
            Init();
            return conn.Table<Appointment>().ToList();
        }
        public void AddAppointment(Appointment app)
        {
            int result = 0;
            Init();
            result = conn.Insert(app);
        }
        public void DeleteAppointment(Appointment app)
        {
            Init();
            conn.Delete(app);
        }
        public Appointment GetAppointmentByID(int AppointmentID)
        {
            Init();
            var temp = from u in conn.Table<Appointment>()
                       where u.Id == AppointmentID
                       select u;
            return  temp.FirstOrDefault();
        }

        public Appointment GetLastAppointment()
        {
            Init();
            return conn.Table<Appointment>().LastOrDefault();
        }

        public void Update(Appointment appointment)
        {
            Init();
            int result = 0;
            result = conn.Update(appointment);
        }
        public List<Goal> GetGoals()
        {
            Init();
            return conn.Table<Goal>().ToList();
        }
        public void AddGoal(Goal temp)
        {
            int result = 0;
            Init();
            result = conn.Insert(temp);
        }
        public void DeleteGoal(Goal temp)
        {
            Init();
            conn.Delete(temp);
        }

        public void UpdateGoal(Goal temp)
        {
            Init();
            int result = 0;
            result = conn.Update(temp);
        }

        public Settings GetSettings()
        {
            Init();
            Settings set = conn.Table<Settings>().FirstOrDefault();

            if (set == null)
            {
                set = new Settings();
                conn.Insert(set);
            }

            return set;
        }

        public void UpdateSettings(Settings settings)
        {
            Init();
            conn.Update(settings);
        }
        public void AddReminder(Reminder reminder)
        {
            int result = 0;
            Init();
            result = conn.Insert(reminder);
        }

        public void UpdateReminder(Reminder reminder)
        {
            int result = 0;
            Init();
            result = conn.Update(reminder);
        }

        public Reminder GetReminderById(int id)
        {
            var temp = from u in conn.Table<Reminder>()
                       where u.IdAppointment == id
                       select u;

            return temp.FirstOrDefault();
        }

        public List<Reminder> GetReminders()
        {
            Init();
            return conn.Table<Reminder>().ToList();
        }
    }
}
