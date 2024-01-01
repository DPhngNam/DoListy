using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using DoListy.Pages;

namespace DoListy.ViewModel
{
    [Table("Appointment")]
    public class Appointment
    { 
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string Name { get; set; }
        public string colorbgString { get; set; } // Store color as a string in SQLite

        [Ignore] // This property will not be stored in SQLite
        public Brush Colorbg
        {
            get
            {
                Brush temp = Brush.Red;
                if (!string.IsNullOrEmpty(colorbgString))
                {
                    switch (colorbgString)
                    {
                        case "Blue":
                            temp = Brush.Blue;
                            break;
                        case "Red":
                            temp = Brush.Red;
                            break;
                        case "Green":
                            temp = Brush.Green;
                            break;
                        case "Orange":
                            temp = Brush.Orange;
                            break;
                        case "Purple":
                            temp = Brush.Purple;
                            break;
                    }
                }
                return temp;
            }
            set { colorbgString = value.ToString(); }
        }
        public DateTime Until { get; set; }
        public string Frequency { get; set; }
        public string Interval { get; set; }
        public string Recurrencerule { get; set; }
        public string Note { get; set; }
        public bool IsDone { get; set; }
        [Ignore]
        public bool isDone
        {
            get
            {
                Appointment temp = App.appointmentRepo.GetAppointmentByID(Id);
                return temp.IsDone;
            }
            set
            {
                OnPropertyChanged(nameof(IsDone));
                UpdateDatabase(value);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateDatabase(bool a)
        {
                Appointment temp = App.appointmentRepo.GetAppointmentByID(Id);

                if (temp != null)
                {
                    temp.IsDone = a;
                    App.appointmentRepo.Update(temp);
                }
        }
    }

    [Table("Goal")]
    public class Goal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        
        public int Year { get; set; }
        public string Notes { get; set; }

        public bool isDone {  get; set; }
    }

    [Table("Reminder")]
    public class Reminder
    {
        [PrimaryKey]
        public int IdAppointment { get; set; }
        public bool IsDismissed { get; set; }
        public int TimeBeforeStart {
            get;
            set; 
        }
        [Ignore]
        public TimeSpan timeBeforeStart
        {
            get
            {
                if (TimeBeforeStart <= 60)
                {
                    return TimeSpan.FromMinutes(TimeBeforeStart);
                }
                else
                {
                    if (TimeBeforeStart % (24 * 60) == 0)
                    {
                        return TimeSpan.FromHours(TimeBeforeStart / (24 * 60));
                    }
                    else
                    {
                        int days = TimeBeforeStart / (24 * 60);
                        int remainingMinutes = TimeBeforeStart % (24 * 60);
                        return TimeSpan.FromDays(days) + TimeSpan.FromMinutes(remainingMinutes);
                    }
                }
            }
        }
    }

    [Table("Settings")]
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public bool Sound { get; set; }

        [Ignore]
        public bool sound
        {
            get 
            { 
                Settings set = App.appointmentRepo.GetSettings();
                return set.Sound;
            }
            set { }
        }

        public bool Mode { get; set; }

        [Ignore]
        public bool mode
        {
            get 
            {
                Settings set = App.appointmentRepo.GetSettings();
                return set.Mode;
            }
            set {   }
        }

        public bool Remind { get; set; }

        [Ignore]
        public bool remind
        {
            get 
            {
                Settings set = App.appointmentRepo.GetSettings();
                return set.Remind;
            }
            set {   }
        }
    }
}
