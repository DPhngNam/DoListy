using DoListy.ViewModel;
using SQLite;

namespace DoListy.Database
{
   public class AppointmentRepository
    {
        string _dbpath;
        private SQLiteAsyncConnection conn;
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
        public async Task< List<Appointment>> GetAll()
        {

            await Init();
            return await conn.Table<Appointment>().ToListAsync();
        }
        public async Task addAppointment(Appointment app )
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
    
    }
}
