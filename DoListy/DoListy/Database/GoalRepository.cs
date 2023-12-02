using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoListy.ViewModel;
using SQLite;

namespace DoListy.Database
{
    internal class GoalRepository
    {
        string _dbpath;
        static SQLiteConnection conn;
        public GoalRepository(string dbpath)
        {
            _dbpath = dbpath;
        }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbpath);
            conn.CreateTable<Goal>();

        }
        public List<Goal> GetGoals()
        {
            Init();
            return conn.Table<Goal>().ToList();
        }
        public void AddAppointment(Goal temp)
        {
            int result = 0;
            Init();
            result = conn.Insert(temp);
        }
        public void DeleteAppointment(Goal temp)
        {
            Init();
            conn.Delete(temp);
        }
        public Goal GetAppointmentByYear(int YearInput)
        {
            var temp = from u in conn.Table<Goal>()
                       where u.Year == YearInput
                       select u;
            return temp.FirstOrDefault();
        }

        public void Update(Goal temp)
        {
            Init();
            int result = 0;
            result = conn.Update(temp);
        }
    }
}
