using DoListy.ViewModel;
using SQLite;

namespace DoListy.Database
{
   public class AppointmentRepository
    {
        string _dbpath;
        private SQLiteConnection conn;
        public AppointmentRepository(string dbpath)
        {
            _dbpath = dbpath;
        }
        public void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection( _dbpath );
            conn.CreateTable<Appointment>();
        }
        public List<Appointment> GetAll()
        {

            Init();
            return conn.Table<Appointment>().ToList();
        }
        public void Add(Appointment appointment)
        {
            
            conn.Insert( appointment );
        }
        public void Delete(Appointment appointment)
        {
            conn.Delete(appointment);
               }
    }
}
