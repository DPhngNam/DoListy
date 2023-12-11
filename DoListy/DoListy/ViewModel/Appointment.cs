using Microsoft.Maui.Controls;
using SQLite;
using System.Collections.ObjectModel;

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
        public string Until { get; set; }
        public bool IsDisMissed { get; set; }
        public string Recurrencerule { get; set; }
        public string Note { get; set; }
        public bool IsDone { get; set; }
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
}
