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
            var temp = from u in conn.Table<Appointment>()
                       where u.Id == AppointmentID
                       select u;
            return  temp.FirstOrDefault();
        }

        public void Update(Appointment appointment)
        {
            Init();
            int result = 0;
            result = conn.Update(appointment);
        }
    }
}
