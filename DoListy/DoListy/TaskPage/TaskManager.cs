using System;
using System.Collections.Generic;
using System.Linq;

namespace DoListy.TaskManager
{
    public class TaskManager
    {
        public static List<Task> TaskToday = new List<Task>()
        {
            new Task
            {
                
                Title = "AAAA"
            }
        };

        public static List<Task> GetTasks() => TaskToday;

        public static void AddTask(Task temp)
        {
            TaskToday.Add(temp);
        }

        
    }
}
