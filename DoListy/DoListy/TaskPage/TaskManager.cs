using DoListy.ViewModel;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoListy.TaskManager
{
    public class TaskManager
    {
        public static List<Task> TaskToday = new List<Task>()
        {
            new Task
            {
                    Id = getlength(),
                    Title = "AAAA",
                    EventStart = new DateTime(2023, 11 ,5,19,30, 30),
                    EventEnd = new DateTime(2023 , 11, 5, 22 , 30 ,30),
                    Tag = "AAAA",
                    State = "AAAA",
            }
        };
        public static List<Task> GetAppointments() => TaskToday;

        public static void AddTask(Task temp)
        {
            TaskToday.Add(temp);
        }

        public static int getlength()
        {
            return TaskToday.Count();
        }
    }
}
