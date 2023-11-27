using DoListy.ViewModel;
using SQLite;

namespace DoListy.Database
{
   public class AppointmentRepository
    {
        string _dbpath;
        static SQLiteAsyncConnection conn;
        public AppointmentRepository(string dbpath)
        {
            _dbpath = dbpath;
        }
        private async Task Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(_dbpath);
            await conn.CreateTableAsync<Appointment>();
        
        }
        public async Task< List<Appointment>> GetAppointments()
        {

            await Init();
            return await conn.Table<Appointment>().ToListAsync();
        }
        public async Task AddAppointment(Appointment app)
        {
            int result = 0;
            await Init();
            result = await conn.InsertAsync(new Appointment());   
        }
        public async Task DeleteAppointment(int id)
        {
            await Init();
            await conn.DeleteAsync(new {ID=id});
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
